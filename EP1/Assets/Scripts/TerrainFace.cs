using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFace
{
    Vector3 normalDirection;
    Vector3 axisA;
    Vector3 axisB;
    int resolution;
    Mesh mesh;

    public TerrainFace(Vector3 normalDirection, int resolution, Mesh mesh)
    {
        this.normalDirection = normalDirection;
        this.resolution = resolution;
        this.mesh = mesh;
        axisA = new Vector3(normalDirection.z, normalDirection.x, normalDirection.y);
        axisB = Vector3.Cross(axisA, normalDirection); 
    }

    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3[resolution * resolution];
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];

        int vertexIndex = 0;
        int triangleIndex = 0;
        for (int i = 0; i < resolution; i++)
        {
            for(int j = 0; j < resolution; j++)
            {
                float percentOnAxisA =  (i / (resolution - 1f) - 0.5f) * 2 ;
                float percentOnAxisB = (j / (resolution - 1f) - 0.5f) *2;
                Vector3 positionOnUnitCube = percentOnAxisA * axisA +
                    percentOnAxisB * axisB + normalDirection;
                Vector3 positionOnUnitSphere = positionOnUnitCube.normalized;
                vertices[vertexIndex] = positionOnUnitSphere;

                if(i != resolution - 1 && j != resolution - 1)
                {
                    triangles[triangleIndex] = vertexIndex;
                    triangles[triangleIndex + 1] = vertexIndex + resolution + 1;
                    triangles[triangleIndex + 2] = vertexIndex + resolution;

                    triangles[triangleIndex + 3] = vertexIndex;
                    triangles[triangleIndex + 4] = vertexIndex + 1;
                    triangles[triangleIndex + 5] = vertexIndex + resolution + 1;
                    triangleIndex += 6;
                }

                vertexIndex++;
            }
        }

        mesh.Clear(); 
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

    }
}
