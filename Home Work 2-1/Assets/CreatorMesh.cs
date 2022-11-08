using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent (typeof(MeshRenderer))]
public class CreatorMesh : MonoBehaviour
{
    Mesh mesh;
    void Start()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = GenerateVertices();
        mesh.triangles = GenerateTriangles();
    }

    Vector3[] GenerateVertices()
    {
        return new Vector3[]
        {
            new Vector3 (1.0f,-1.0f,-1.0f),
            new Vector3 (1.0f,-1.0f,1.0f),
            new Vector3 (-1.0f,-1.0f,-1.0f),
            new Vector3 (-1.0f,-1.0f,1.0f),
            new Vector3 (1.0f, 1.0f, -1.0f),
            new Vector3 (1.0f, 1.0f, 1.0f),
            new Vector3 (-1.0f, 1.0f, -1.0f),
            new Vector3 (-1.0f, 1.0f, 1.0f)
        };
    }

    int[] GenerateTriangles()
    {
        return new int[] { 0, 2, 3, 3, 1, 0, 3, 7, 2, 7, 6, 2, 0, 4, 5, 5, 0, 1,1, 5, 7, 7, 3, 1, 5, 4,7, 4, 6, 7, 4, 0, 6, 0, 2, 6 };
    }
}
