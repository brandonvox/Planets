using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSettings shapeSettings;

    public ShapeGenerator(ShapeSettings shapeSettings)
    {
        this.shapeSettings = shapeSettings;
    }

    public Vector3 CalculatePositionOnPlanet(Vector3 positionOnUnitSphere)
    {
        return positionOnUnitSphere * shapeSettings.planetRadius;
    }
}
