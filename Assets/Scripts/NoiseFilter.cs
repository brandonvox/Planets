using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter
{
    NoiseSettings noiseSettings;
    Noise noise = new Noise();

    public NoiseFilter(NoiseSettings noiseSettings)
    {
        this.noiseSettings = noiseSettings;
    }

    public float Evaluate(Vector3 position)
    {
        float totalNoiseValue = 0f;
        float frequency = noiseSettings.baseLacunarity;
        float amplitude = 1f;

        for(int i = 0; i< noiseSettings.numberOfLayers; i++)
        {
            float noiseValue = noise.Evaluate(position * frequency + noiseSettings.centerPosition);
            noiseValue = (noiseValue + 1) / 2f;
            noiseValue = noiseValue * amplitude;
            totalNoiseValue += noiseValue;
            frequency *= noiseSettings.lacunarity;
            amplitude *= noiseSettings.persistence;
        }


        return Mathf.Max(0, totalNoiseValue - noiseSettings.minValue) * noiseSettings.strength;

    }
}
