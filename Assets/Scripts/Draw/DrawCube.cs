using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrawCube : MonoBehaviour
{
    QuaternionManager myQuaternion = new();
    [Header("Quaterion component")]
    [SerializeField]
    [Range(0, 360)]
    float angle = 0.00f;
    [SerializeField] Vector3 axis = Vector3.zero;
    [SerializeField] Slider angleSlider;
    [SerializeField] TextMeshProUGUI valueAngle;
    [SerializeField] Toggle toggleX;
    [SerializeField] Toggle toggleY;
    [SerializeField] Toggle toggleZ;
    private int axisX = 0;
    private int axisY = 0;
    private int axisZ = 0;

    [Header("Scale component")]
    [SerializeField] Vector3 scale = Vector3.one;
    ScaleManager myScale = new();
    [SerializeField] TMP_InputField scaleX;
    [SerializeField] TMP_InputField scaleY;
    [SerializeField] TMP_InputField scaleZ;
    private float scX;
    private float scY;
    private float scZ;

    [Header("Position component")]
    [SerializeField] Vector3 position = Vector3.zero;
    PositionManager myPos = new();
    [SerializeField] TMP_InputField positionX;
    [SerializeField] TMP_InputField positionY;
    [SerializeField] TMP_InputField positionZ;
    private int posX;
    private int posY;
    private int posZ;

    private LineRenderer lineRenderer;

    private Vector3[] vertices = new Vector3[]
    {        
        new Vector3(-0.5f, -0.5f, -0.5f), // Vertex 0
        new Vector3(0.5f, -0.5f, -0.5f),  // Vertex 1
        new Vector3(0.5f, -0.5f, 0.5f),   // Vertex 2
        new Vector3(-0.5f, -0.5f, 0.5f),  // Vertex 3
        new Vector3(-0.5f, 0.5f, -0.5f),  // Vertex 4
        new Vector3(0.5f, 0.5f, -0.5f),   // Vertex 5
        new Vector3(0.5f, 0.5f, 0.5f),    // Vertex 6
        new Vector3(-0.5f, 0.5f, 0.5f)    // Vertex 7

    };

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        scaleX.text = "1"; scaleY.text = "1"; scaleZ.text = "1";   
        positionX.text = "0"; positionY.text = "0"; positionZ.text = "0";
    }

    private void Update()
    {

        Convertion();
        RestartCubePosition();
        RotationCube();
        ResizeCube();
        SetPosition();
        DrawCube3D();
    }
    /// <summary>
    /// Converts all values that it gets in canvas to a number that it can use to replace values in the code
    /// </summary>
    private void Convertion()
    {
        //equals the value on slider to value in angle, later took a toogle to know through which one axis rotate
        angle = angleSlider.value;
        valueAngle.text = angle.ToString("F1");//Use "F1" to put one decimmal after point, you can change the value to get more numbers after decimmal point
        if (toggleX.isOn)
            axisX = 1;
        else axisX = 0;
        if (toggleY.isOn)
            axisY = 1;
        else axisY = 0;
        if (toggleZ.isOn)
            axisZ = 1;
        else axisZ = 0;
        axis = new(axisX, axisY, axisZ);

        //Converts Scale input field on float values
        try
        {
            scX = float.Parse(scaleX.text);
        }
        catch (SystemException)
        {
            scX = 1;
        }

        try
        {
            scY = float.Parse(scaleY.text);
        }
        catch (SystemException)
        {
            scY = 1;
        }

        try
        {
            scZ = float.Parse(scaleZ.text);
        }
        catch (SystemException)
        {
            scZ = 1;
        }

        scale = new(scX, scY, scZ);

        //Transforms position values in input field on int values
        try
        {
            posX = int.Parse(positionX.text);
        }
        catch (SystemException)
        {
            posX = 0;
        }

        try
        {
            posY = int.Parse(positionY.text);
        }
        catch (SystemException)
        {
            posY = 0;
        }

        try
        {
            posZ = int.Parse(positionZ.text);
        }
        catch (SystemException)
        {
            posZ = 0;
        }


        position = new(posX, posY, posZ);
    }

    private void RestartCubePosition()
    {
        vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f), // Vertex 0
            new Vector3(0.5f, -0.5f, -0.5f),  // Vertex 1
            new Vector3(0.5f, -0.5f, 0.5f),   // Vertex 2
            new Vector3(-0.5f, -0.5f, 0.5f),  // Vertex 3
            new Vector3(-0.5f, 0.5f, -0.5f),  // Vertex 4
            new Vector3(0.5f, 0.5f, -0.5f),   // Vertex 5
            new Vector3(0.5f, 0.5f, 0.5f),    // Vertex 6
            new Vector3(-0.5f, 0.5f, 0.5f)    // Vertex 7

        };
    }

    private void DrawCube3D()
    {
        // vertex on linerenderer
        lineRenderer.positionCount = vertices.Length;
        lineRenderer.SetPositions(vertices);

        // define lines that conect vertex
        int[] cubeIndex = new int[]
        {
            0,1,1,2,2,3,3,0, // bottom cube face
            4,5,5,6,6,7,7,4, // upper cube face
            0,4,1,5,2,6,3,7
        };

        // draw lines
        lineRenderer.positionCount = cubeIndex.Length;
        for(int i = 0; i < cubeIndex.Length; i++)
        {
            lineRenderer.SetPosition(i, vertices[cubeIndex[i]]);
        }
    }

    private void RotationCube()
    {
        for (int i = 0;i < vertices.Length;i++)
        {
            vertices[i] = myQuaternion.RotatePoint(angle, axis, vertices[i]);
        }
    }

    private void ResizeCube()
    {
        for(int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = myScale.ScalePoint(scale, vertices[i]);
        }
    }

    private void SetPosition()
    {
        for(int i=0; i < vertices.Length; i++)
        {
            vertices[i] = myPos.SetPointPos(position, vertices[i]);
        }
    }
}
