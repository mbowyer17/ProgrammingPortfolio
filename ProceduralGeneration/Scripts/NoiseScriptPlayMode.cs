using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NoiseScriptPlayMode : MonoBehaviour
{
     public int seed;
    public int seedMin = 0;
    public int seedMax = Int32.MaxValue;

    [SerializeField] private GameObject parentSeed;
    
    // A good balance between detail and performance.
    public int octaves = 8;
    public int octavesMin = 6;
    public int octavesMax = 9;

    //This affects the distance between feature points. Higher values create more detailed terrain, but can also make it look unrealistic if too high.
    public float lacunarity; // 2.5
    public float lacunarityMin = 0.4f;
    public float lacunarityMax = 0.6f;

    // This affects the amplitude of each octave. Lower values create smoother terrain, while higher values create more jagged terrain.
    public float persistence; // 0.5
    public float persistenceMin = 0.3f;
    public float persistenceMax = 0.5f;

    //  This affects the scale of the features. Higher values create smaller features, while lower values create larger features.
    public float frequency; // 1
    public float frequencyMin = 1f;
    public float frequencyMax = 20f;

    // This affects the overall height of the terrain.
    public float amplitude; // 1
    public float amplitudeMin = 0.1f;
    public float amplitudeMax = 0.3f;

    // This affects the amount of detail in the terrain. Higher values create more detail, but can also make the terrain look noisy.
    public float roughness; // 2 15 best
    public float roughessMin = 4f;
    public float roughnessMax = 15f;

    private Vector3 scale;
    private float scaleMin = 3f;
    private float scaleMax = 4f;
    private System.Random prng;

  
    void Start()
    {
        GenerateSeed();
        GenerateNoise();
        this.gameObject.transform.localScale = scale;
    }

    private void GenerateSeed()
    {
        seed = Random.Range(seedMin, seedMax);
        //NextDouble method to generate a random floating point value between the respective minimum and maximum values.
        prng = new System.Random(seed);
        scale = gameObject.transform.localScale;

        //seed = (int)prng.Next() * (seedMax - seedMin);
        //octaves = (int)prng.Next() * (octavesMax - octavesMin);
        lacunarity = (float)prng.NextDouble() * (lacunarityMax - lacunarityMin);
        persistence = (float)prng.NextDouble() * (persistenceMax - persistenceMin);
        frequency = (float)prng.NextDouble() * (frequencyMax - frequencyMin);
       
        amplitude = (float)prng.NextDouble() * (amplitudeMax - amplitudeMin);
        roughness = (float)prng.NextDouble() * (roughnessMax - roughessMin);
        //roughness = 8f;
        float scaleRng = (float)prng.NextDouble() * (scaleMax - scaleMin);
        scale = new Vector3(1, 1, 1);
    }

    private void GenerateNoise()
    {
        MeshFilter filter = GetComponent<MeshFilter>();
        Vector3[] vertices = filter.mesh.vertices;
        
        // Iterate through each vertex in the mesh
        for (int i = 0; i < vertices.Length; i++)
        {
            // Calculate the x, y, and z coordinates for each vertex by multiplying the original coordinates with the frequency value
            float xCoord = vertices[i].x * frequency;
            float yCoord = vertices[i].y * frequency;
            float zCoord = vertices[i].z * frequency;

            // Initialize the noise value to 0
            float noise = 0f;

            // Set the amplitude value to the maximum value
            float amp = amplitude;

            // Iterate through each octave
            for (int o = 0; o < octaves; o++)
            {
                // Generate Perlin noise value for the current octave using the x and z coordinates
                float layerNoise = Mathf.PerlinNoise(xCoord, zCoord);

                // Raise the noise value to the power of the roughness value to increase the contrast of the noise
                layerNoise = Mathf.Pow(layerNoise, roughness);

                // Add the current octave's noise value multiplied by the current amplitude value to the total noise value
                noise += layerNoise * amp;

                // Multiply the x, y, and z coordinates with the lacunarity value to increase the frequency for the next octave
                xCoord *= lacunarity;
                yCoord *= lacunarity;
                zCoord *= lacunarity;

                // Multiply the amplitude with the persistence value to decrease the amplitude for the next octave
                amp *= persistence;
            }

            // Scale the vertex normal vector with the sum of the original vector and the noise value multiplied by the amplitude value
            vertices[i] = vertices[i].normalized * (1f + noise);
        }

        // Set the updated vertices back to the mesh filter component
        filter.mesh.vertices = vertices;

        // Recalculate the normals of the mesh to ensure smooth shading
        filter.mesh.RecalculateNormals();

    }
}
