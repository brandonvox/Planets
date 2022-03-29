using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    TerrainFace[] terrainFaces;
    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    [Range(2, 256)]
    public int resolution = 10;

    public Material planetMaterial;
    void Init()
    {
        terrainFaces = new TerrainFace[6];
        if(meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }
        Vector3[] normalVectors =
        {
            Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back
        };

        for (int i = 0; i < 6; i++)
        {
            if(meshFilters[i] == null)
            {
                GameObject terrainObject = new GameObject("Terrain " + i);
                terrainObject.transform.parent = transform;
                meshFilters[i] = terrainObject.AddComponent<MeshFilter>();
                terrainObject.AddComponent<MeshRenderer>();

                meshFilters[i].sharedMesh = new Mesh();
            }
            meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial = planetMaterial;
            terrainFaces[i] = new TerrainFace(normalVectors[i], resolution, meshFilters[i].sharedMesh);
        }


    }

    public void GenerateMesh()
    {
        for (int i = 0; i < 6; i++)
        {
            terrainFaces[i].ConstructMesh(); 
        }
    }

    public void OnValidate()
    {
        GeneratePlanet();
    }

    private void GeneratePlanet()
    {
        Init();
        GenerateMesh();
    }
}
