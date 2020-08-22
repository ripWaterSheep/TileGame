﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGen
{
    public const int width = 511;
    public const int height = 511;
    const float noiseScale = 15; // Smaller number is larger features, larger number is smaller features

    public static float[,] noisemap;

    public static Vector3 ClampComponentsInside(Vector3 v)
    {
        return new Vector3(Mathf.Clamp(v.x, 0, NoiseGen.width - 1), Mathf.Clamp(v.y, 0, NoiseGen.height - 1), 0);
    }

    public static Vector3Int ClampComponentsInside(Vector3Int v)
    {
        return new Vector3Int(Mathf.Clamp(v.x, 0, NoiseGen.width - 1), Mathf.Clamp(v.y, 0, NoiseGen.height - 1), 0);
    }

    static float GetNoise(int x, int y, float scale, float seed)
    {
        return Mathf.PerlinNoise((x / (float)width) * scale + seed, (y / (float)height) * scale + seed);
    }

    public static void Generate(float seed)
    {
        noisemap = new float[width, height];
        Debug.Log("Seed: " + seed);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float noiseVal = GetNoise(x, y, noiseScale, seed); // Large featues
                noiseVal += 0.5f * GetNoise(x, y, noiseScale * 2, seed); // Small details
                noiseVal /= 1.41f;

                noisemap[x, y] = noiseVal;
            }
        }
    }

    public static void Generate()
    {
        Generate(Random.Range(0, 99999.99f));
    }
}
