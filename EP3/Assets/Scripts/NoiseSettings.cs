using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings
{
    [Range(1, 8)]
    public int numberOfLayers = 1;
    public float baseLacunarity = 1f;
    public float lacunarity = 2f;
    public float persistence = 0.5f;
    public float minValue;
    public float strength = 1f;
    public Vector3 centerPosition;
}
