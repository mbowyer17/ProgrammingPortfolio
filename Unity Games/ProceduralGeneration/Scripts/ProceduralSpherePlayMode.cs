using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ProceduralSpherePlayMode : MonoBehaviour
{
     // Start is called before the first frame update
    private Mesh mesh;
    private MeshFilter meshFilter;
    public Vector3[] vertices;
    public int nbLon;
    public int nbLa;
    [SerializeField] private List<Material> planetMaterials;
    [SerializeField] private bool noiseBool;
    [SerializeField] private bool voronoiBool;
    void Start()
    {
        GenerateSphere(1f, nbLon, nbLa); // 255 is max for 8bit system
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        Renderer renderer = GetComponent<Renderer>();
        //renderer.material = planetMaterials[Random.Range(0, 6)];
    }

    private void GenerateSphere(float radius, int nbLong, int nbLat)
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        mesh.Clear();

        #region Vertices

        vertices = new Vector3[(nbLong + 1) * nbLat + 2];
        float pi = Mathf.PI;
        float twoPi = pi * 2f;

        vertices[0] = Vector3.up * radius;
        for (int lat = 0; lat < nbLat; lat++)
        {
            float a1 = pi * (float)(lat + 1) / (nbLat + 1);
            float sin1 = Mathf.Sin(a1);
            float cos1 = Mathf.Cos(a1);
            for (int lon = 0; lon <= nbLong; lon++)
            {
                float a2 = twoPi * (float)(lon == nbLong ? 0 : lon) / nbLong;
                float sin2 = Mathf.Sin(a2);
                float cos2 = Mathf.Cos(a2);

                vertices[lon + lat * (nbLong + 1) + 1] = new Vector3(sin1 * cos2, cos1, sin1 * sin2) * radius;
            }
        }
        vertices[vertices.Length - 1] = Vector3.up * -radius;
        #endregion

        #region Normals

        Vector3[] normales = new Vector3[vertices.Length];
        for (int n = 0; n < vertices.Length; n++)
        {
            normales[n] = vertices[n].normalized;
        }
        #endregion

        #region UVs 

        Vector2[] uvs = new Vector2[vertices.Length];
        uvs[0] = Vector2.up;
        uvs[uvs.Length - 1] = Vector2.zero;
        for (int lat = 0; lat < nbLat; lat++)
        {
            for (int lon = 0; lon <= nbLong; lon++)
            {
                uvs[lon + lat * (nbLong + 1) + 1] =
                    new Vector2((float)lon / nbLong, 1f - (float)(lat + 1) / (nbLat + 1));
                
            }
        }
        #endregion

        #region Triangles

        int nbFaces = vertices.Length;
        int nbTriangles = nbFaces * 2;
        int nbIndexes = nbTriangles * 3;
        int[] triangles = new int[nbIndexes];
        
        // Top Cap
        int i = 0;
        for (int lon = 0; lon < nbLong; lon++)
        {
            triangles[i++] = lon + 2;
            triangles[i++] = lon + 1;
            triangles[i++] = 0;
        }
        
        // Middle
        for (int lat = 0; lat < nbLat - 1; lat++)
        {
            for (int lon = 0; lon < nbLong; lon++)
            {
                int current = lon + lat * (nbLong + 1) + 1;
                int next = current + nbLong + 1;

                triangles[i++] = current;
                triangles[i++] = current + 1;
                triangles[i++] = next + 1;

                triangles[i++] = current;
                triangles[i++] = next + 1;
                triangles[i++] = next;
            }
        }
        
        // Bottom Cap
        for (int lon = 0; lon < nbLong; lon++)
        {
            triangles[i++] = vertices.Length - 1;
            triangles[i++] = vertices.Length - (lon + 2) - 1;
            triangles[i++] = vertices.Length - (lon + 1) - 1;
        }

        mesh.vertices = vertices;
        mesh.normals = normales;
        mesh.uv = uvs;
        mesh.triangles = triangles;
        

        mesh.RecalculateBounds();
        mesh.Optimize();

        #endregion

        if (noiseBool)
        {
            gameObject.AddComponent<NoiseScriptPlayMode>();
        }

        if (voronoiBool)
        {
            gameObject.AddComponent<VoronoiMeshEditor>();
        }
        
    }
}
