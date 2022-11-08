using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class MeshCreatorHomeWork : MonoBehaviour
{
    [SerializeField] float width = 5; //z
    [SerializeField] float length = 5; //x

    public GameObject firstObj;
    public GameObject secondObj;
    public GameObject objFirst;
    public GameObject objSecond;

    private List<GameObject> objList = new List<GameObject>(1);
    private float lengthDifference = 0;
    Mesh meshBasic;
    Mesh meshFirstObj;
    Mesh meshSecondObj;
    float intermediateLengthDifference = 0.0f;

    void Start()
    {
        meshBasic = new Mesh();

        objList.Add(firstObj);

        GetComponent<MeshFilter>().mesh = meshBasic;
        meshBasic.vertices = GenerateVertices();
        meshBasic.triangles = GenerateTriangles();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lengthDifference = LengthDifference();

            if (lengthDifference>=0)
            {
                intermediateLengthDifference = lengthDifference;
            }
            else
            {
                intermediateLengthDifference = lengthDifference * -1;
            }
            
            length -= intermediateLengthDifference;
            
            GameObject firsPref = Instantiate(objFirst);
            GameObject secondPref = Instantiate(objSecond);

            if (lengthDifference>=0)
            {
                firsPref.transform.position = new Vector3(secondObj.transform.position.x - lengthDifference / 2, secondObj.transform.position.y, secondObj.transform.position.z);

                secondPref.transform.position = new Vector3(firsPref.transform.position.x + lengthDifference + length / 2, firsPref.transform.position.y, firsPref.transform.position.z);
            }
            else
            {
                firsPref.transform.position = new Vector3(secondObj.transform.position.x + intermediateLengthDifference / 2, secondObj.transform.position.y, secondObj.transform.position.z);

                secondPref.transform.position = new Vector3(firsPref.transform.position.x - (intermediateLengthDifference + length / 2), firsPref.transform.position.y, firsPref.transform.position.z);
            }

            meshFirstObj = new Mesh();
            firsPref.GetComponent<MeshFilter>().mesh = meshFirstObj;
            objList.Add(firsPref);

            meshSecondObj = new Mesh();
            secondPref.GetComponent<MeshFilter>().mesh = meshSecondObj;

            CreatorFirstMesh(length, width);
            CreatorSecondMesh(lengthDifference, width);

            meshBasic.vertices = GenerateVertices();
            meshBasic.triangles = GenerateTriangles();

        }
    }

    Vector3[] GenerateVertices()
    {
        return new Vector3[]
        {
            new Vector3 (length/2f, 0.5f, width/2f),//0
            new Vector3 (length/2f, -0.5f, width/2f),//1
            new Vector3 (-(length/2f), 0.5f, width/2f),//2
            new Vector3 (-(length/2f), -0.5f, width/2f),//3
            new Vector3 (-(length/2f), 0.5f, -(width/2f)),//4
            new Vector3 (-(length/2f), -0.5f, -(width/2f)),//5
            new Vector3 (length/2f, 0.5f, -(width/2f)),//6
            new Vector3 (length/2f, -0.5f, -(width/2f)),//7
        };
    }

    int[] GenerateTriangles()
    {
        return new int[] { 0, 2, 1, 1, 2, 3, 2, 4, 5, 2, 5, 3, 0, 6, 4, 0, 4, 2, 6, 0, 7, 7, 0, 1, 5, 4, 6, 5, 6, 7 };
    }

    float LengthDifference()
    {
        int indexator = objList.Count - 1;
        
        lengthDifference =  secondObj.transform.position.x - objList[indexator].transform.position.x;

        return lengthDifference;
    }

    void CreatorFirstMesh(float length, float width)
    {

        meshFirstObj.vertices = new Vector3[] 
        {
            new Vector3 (length/2f, 0.5f, width/2f),//0
            new Vector3 (length/2f, -0.5f, width/2f),//1
            new Vector3 (-(length/2f), 0.5f, width/2f),//2
            new Vector3 (-(length/2f), -0.5f, width/2f),//3
            new Vector3 (-(length/2f), 0.5f, -(width/2f)),//4
            new Vector3 (-(length/2f), -0.5f, -(width/2f)),//5
            new Vector3 (length/2f, 0.5f, -(width/2f)),//6
            new Vector3 (length/2f, -0.5f, -(width/2f)),//7
        };
        meshFirstObj.triangles = new int[]
        {
            0, 2, 1, 1, 2, 3, 2, 4, 5, 2, 5, 3, 0, 6, 4, 0, 4, 2, 6, 0, 7, 7, 0, 1, 5, 4, 6, 5, 6, 7
        };
    }

    void CreatorSecondMesh(float lengthDifference, float width)
    {
        meshSecondObj.vertices = new Vector3[]
        {
            new Vector3 (lengthDifference/2f, 0.5f, width/2f),//0
            new Vector3 (lengthDifference/2f, -0.5f, width/2f),//1
            new Vector3 (-(lengthDifference/2f), 0.5f, width/2f),//2
            new Vector3 (-(lengthDifference/2f), -0.5f, width/2f),//3
            new Vector3 (-(lengthDifference/2f), 0.5f, -(width/2f)),//4
            new Vector3 (-(lengthDifference/2f), -0.5f, -(width/2f)),//5
            new Vector3 (lengthDifference/2f, 0.5f, -(width/2f)),//6
            new Vector3 (lengthDifference/2f, -0.5f, -(width/2f)),//7
        };

        meshSecondObj.triangles = new int[]
        {
            0, 2, 1, 1, 2, 3, 2, 4, 5, 2, 5, 3, 0, 6, 4, 0, 4, 2, 6, 0, 7, 7, 0, 1, 5, 4, 6, 5, 6, 7
        };
    }
}
