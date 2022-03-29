using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSettings shapeSettings;
    NoiseFilter noiseFilter;

    public ShapeGenerator(ShapeSettings shapeSettings)
    {
        this.shapeSettings = shapeSettings;
        noiseFilter = new NoiseFilter(shapeSettings.noiseSettings);
    }

    public Vector3 CalculatePositionOnPlanet(Vector3 positionOnUnitSphere)
    {
        return positionOnUnitSphere * shapeSettings.planetRadius *(1 +  noiseFilter.Evaluate(positionOnUnitSphere));
    }
}
