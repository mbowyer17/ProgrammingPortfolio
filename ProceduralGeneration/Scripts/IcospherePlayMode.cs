using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcospherePlayMode : MonoBehaviour
{
      public float radius = 1.0f;
      public int subdivisions = 2;
      [SerializeField] private bool noiseBool, voronoiBool;
      [SerializeField] int vertexCount;
      void Start()
      {
          MeshFilter meshFilter = GetComponent<MeshFilter>();
          meshFilter.mesh = GenerateIcosphere(radius, subdivisions); 
          if (noiseBool)
          {
              gameObject.AddComponent<NoiseScriptPlayMode>();
          }

          if (voronoiBool)
          {
              gameObject.AddComponent<VoronoiMeshEditor>();
          }
          
      }

      Mesh GenerateIcosphere(float radius, int subdivisions)
      {
          Mesh mesh = new Mesh();

          List<Vector3> vertices = new List<Vector3>();
          List<int> triangles = new List<int>();
          List<Vector3> normals = new List<Vector3>();

          float t = (1.0f + Mathf.Sqrt(5.0f)) / 2.0f;
         

          vertices.Add(new Vector3(-1, t, 0).normalized * radius);
          vertices.Add(new Vector3(1,t, 0).normalized * radius);
          vertices.Add(new Vector3(-1, -t, 0f).normalized * radius);
          vertices.Add(new Vector3(1f, -t, 0).normalized * radius);

          vertices.Add(new Vector3(0.0f, -1.0f, t).normalized * radius);
          vertices.Add(new Vector3(0.0f, 1.0f, t).normalized * radius);
          vertices.Add(new Vector3(0.0f, -1.0f, -t).normalized * radius);
          vertices.Add(new Vector3(0.0f, 1.0f, -t).normalized * radius);

          vertices.Add(new Vector3(t, 0.0f, -1.0f).normalized * radius);
          vertices.Add(new Vector3(t, 0.0f, 1.0f).normalized * radius);
          vertices.Add(new Vector3(-t, 0.0f, -1.0f).normalized * radius);
          vertices.Add(new Vector3(-t, 0.0f, 1.0f).normalized * radius);

          #region Triangles
          // Create icosahedron
          triangles.Add(0);
          triangles.Add(11);
          triangles.Add(5);

          triangles.Add(0);
          triangles.Add(5);
          triangles.Add(1);

          triangles.Add(0);
          triangles.Add(1);
          triangles.Add(7);

          triangles.Add(0);
          triangles.Add(7);
          triangles.Add(10);

          triangles.Add(0);
          triangles.Add(10);
          triangles.Add(11);

          triangles.Add(1);
          triangles.Add(5);
          triangles.Add(9);

          triangles.Add(5);
          triangles.Add(11);
          triangles.Add(4);

          triangles.Add(11);
          triangles.Add(10);
          triangles.Add(2);

          triangles.Add(10);
          triangles.Add(7);
          triangles.Add(6);

          triangles.Add(7);
          triangles.Add(1);
          triangles.Add(8);

          triangles.Add(3);
          triangles.Add(9);
          triangles.Add(4);

          triangles.Add(3);
          triangles.Add(4);
          triangles.Add(2);

          triangles.Add(3);
          triangles.Add(2);
          triangles.Add(6);

          triangles.Add(3);
          triangles.Add(6);
          triangles.Add(8);

          triangles.Add(3);
          triangles.Add(8);
          triangles.Add(9);
          
          triangles.Add(4);
          triangles.Add(9);
          triangles.Add(5);
          
          triangles.Add(2);
          triangles.Add(4);
          triangles.Add(11);
          
          triangles.Add(6);
          triangles.Add(2);
          triangles.Add(10);
          
          triangles.Add(8);
          triangles.Add(6);
          triangles.Add(7);
          
          triangles.Add(9);
          triangles.Add(8);
          triangles.Add(1);
          #endregion
          // Normalize vertices
          for (int i = 0; i < vertices.Count; i++)
          {
              vertices[i] = vertices[i].normalized;
          }

          // Refine triangles
          for (int i = 0; i < subdivisions; i++)
          {
              List<int> newTriangles = new List<int>();

              for (int j = 0; j < triangles.Count; j += 3)
              {
                  int v1 = triangles[j];
                  int v2 = triangles[j + 1];
                  int v3 = triangles[j + 2];

                  int v4 = vertices.Count;
                  int v5 = vertices.Count + 1;
                  int v6 = vertices.Count + 2;
                  Vector3 vertex4 = (vertices[v1] + vertices[v2]).normalized * radius;
                  Vector3 vertex5 = (vertices[v2] + vertices[v3]).normalized * radius;
                  Vector3 vertex6 = (vertices[v3] + vertices[v1]).normalized * radius;

                  vertices.Add(vertex4);
                  vertices.Add(vertex5);
                  vertices.Add(vertex6);

                  newTriangles.Add(v1);
                  newTriangles.Add(v4);
                  newTriangles.Add(v6);

                  newTriangles.Add(v2);
                  newTriangles.Add(v5);
                  newTriangles.Add(v4);

                  newTriangles.Add(v3);
                  newTriangles.Add(v6);
                  newTriangles.Add(v5);

                  newTriangles.Add(v4);
                  newTriangles.Add(v5);
                  newTriangles.Add(v6);
              }

              triangles = newTriangles;
          }

// Calculate normals
          for (int i = 0; i < vertices.Count; i++)
          {
              normals.Add(vertices[i].normalized);
          }

// Assign vertices, triangles, and normals to mesh
          mesh.vertices = vertices.ToArray();
          mesh.triangles = triangles.ToArray();
          mesh.normals = normals.ToArray();
          vertexCount= mesh.vertexCount;

          return mesh;
      }
}
