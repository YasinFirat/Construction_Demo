 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Unutulması ihtimal bilgiler; 
/// 
/// squareSize*squareAmount*spacingOfvertex = 10 => transform scale =1;
/// 
/// soldaki işleme meshInfo diye birim tanımlarsan  MI/10= 1 scale 
/// 
/// eğer MI = 20 => scale=2 olur , MI=15 ise scale=1.5 olur.
/// </summary>

[RequireComponent(typeof(MeshRenderer),typeof(MeshFilter),typeof(MeshCollider))]
public class MeshController : ConstructionGame
{
    private Vector3[] verticles;
    private int[] triangles;

    private Mesh mesh;
    private MeshCollider meshCollider;

    private MeshInfo meshInfo;

    private void Start()
    {
        meshInfo = gameManager.meshInfo;

        meshInfo.deep = meshInfo.squareAmount - (meshInfo.squareAmount * meshInfo.perCentDeep) / 100;
        CreatePlane().CreateMesh();

    }
   
    public void ConstructionMesh(RaycastHit hit,bool canExcavate)
    {
       // Ray ray = Camera.main.ScreenPointToRay(touchPosition);
       // RaycastHit hit;
        int triangleIndex = -1;
        if(canExcavate)
        {
            triangleIndex = hit.triangleIndex;
           
        }
        else
        {
            return;
        }
        float addHeight = -.5f;
        

        int[] keepV = new int[6];
        if (triangleIndex % 2 == 0)
        {
            for (int i = 0; i < keepV.Length; i++)
            {
                keepV[i] = (triangleIndex + (i / 3)) * 3 + i % 3;
            }
            
        }
        else
        {
            for (int i = 0; i < keepV.Length; i++)
            {
                keepV[i] = (triangleIndex - (i / 3)) * 3 + i % 3;
            }
           
        }

        for (int i = 0; i < keepV.Length; i++)
        {
            if (verticles[triangles[keepV[i]]].y > meshInfo.maxDeep)
                verticles[triangles[keepV[i]]].y += addHeight;
        }
       
        CreateMesh();
        
    }
    public MeshController CreatePlane()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        meshCollider = GetComponent<MeshCollider>();

        verticles = new Vector3[(meshInfo.squareAmount + 1) * (meshInfo.squareAmount + 1)];
        triangles = new int[meshInfo.squareAmount * meshInfo.squareAmount * 6];

        float vertexSpacing = meshInfo.squareSize * meshInfo.spacingOfVertex;

        int v=0,t = 0;

        

        for (int x = 0; x <= meshInfo.squareAmount; x++)
        {
            for (int z = 0; z <= meshInfo.squareAmount; z++)
            {
                if (z < meshInfo.deep)
                {
                    verticles[v] = new Vector3((x * vertexSpacing), 0, z * vertexSpacing);
                }
                else
                {
                    verticles[v] = new Vector3((x * vertexSpacing), meshInfo.maxDeep, z * vertexSpacing);
                }
               

                v++;
            }
            
        }
        v = 0;
        for (int x = 0; x < meshInfo.squareAmount; x++)
        {
            for (int z = 0; z < meshInfo.squareAmount; z++)
            {
                triangles[t] = v;
                triangles[t+1] = v + 1;
                triangles[t+2] = v + (meshInfo.squareAmount + 1);
                triangles[t+3] = v + (meshInfo.squareAmount + 1);
                triangles[t+4] = v + 1;
                triangles[t+5] = v + 1 + (meshInfo.squareAmount + 1);
                v++;
                t += 6;
               
            }
            v++;
        }
        return this;
    }

    public MeshController CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = verticles;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        meshCollider.sharedMesh = mesh;
        return this;

    }



}
