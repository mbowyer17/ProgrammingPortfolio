using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class VoronoiMeshEditor : MonoBehaviour
{
    public int numCells;
    public int numCellsMax = 100;
    public int numCellsMin = 30;
    
    public float sphereRadius = 1.0f;

    public float noiseScale;
    public float noiseScaleMax = 50 ;
    public float noiseScaleMin = 1;
    public float mountainSize;
    public float mountainSizeMax = 0.1f;
    public float mountainSizeMin = 0.3f;

    private List<Vector3> cellCenters = new List<Vector3>();

    void Start()
    {
        numCells = Random.Range(numCellsMin, numCellsMax);
        noiseScale = Random.Range(noiseScaleMax, noiseScaleMax);
        mountainSize = Random.Range(mountainSizeMin, mountainSizeMax);
        GenerateCells();
        EditMesh();
    }
    void GenerateCells()
    {
        for (int i = 0; i < numCells; i++)
        {
            Vector3 center = Random.insideUnitSphere.normalized * sphereRadius;
            cellCenters.Add(center);
        }
    }

    void EditMesh()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        List<Vector3> vertices = new List<Vector3>(mesh.vertices);
        List<int> triangles = new List<int>(mesh.triangles);

        // Create a new list of vertex positions based on the old vertex positions
        List<Vector3> newVertices = new List<Vector3>();
        for (int i = 0; i < vertices.Count; i++)
        {
            Vector3 vertex = vertices[i];

            // Compute the new vertex position based on the Voronoi diagram and the noise function
            Vector3 noiseVector = vertex.normalized * noiseScale;
            float noise = Mathf.PerlinNoise(noiseVector.x, noiseVector.y);
            float mountainHeight = ComputeMountainHeight(vertex, noise);
            Vector3 newVertex = vertex.normalized * (sphereRadius + mountainHeight);

            newVertices.Add(newVertex);
        }

        mesh.vertices = newVertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }

    float ComputeMountainHeight(Vector3 vertex, float noise)
    {
        float distanceToClosestCell = float.MaxValue;

        for (int i = 0; i < cellCenters.Count; i++)
        {
            float distance = Vector3.Distance(vertex, cellCenters[i]);
            if (distance < distanceToClosestCell)
            {
                distanceToClosestCell = distance;
            }
        }

        float mountainHeight = 0.0f;
        //Debug.Log("Distance to closest cell: " + distanceToClosestCell);

        if (distanceToClosestCell < sphereRadius * mountainSize)
        {
            mountainHeight = (1.0f - distanceToClosestCell / (sphereRadius * mountainSize)) * noise * 0.1f;
        }

        return mountainHeight;
    }
}