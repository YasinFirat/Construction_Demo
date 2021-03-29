using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DrawNest : MonoBehaviour
{
    public int segments=10;
    
    private float xScale=.5f;
    private float yScale=.5f;
   
    
    LineRenderer line;

    
    public void CreateSquare()
    {
        line = GetComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.positionCount = 4; 
        line.loop = true;

        line.SetPosition(0,new Vector3(-xScale,-yScale,-1));
        line.SetPosition(1,new Vector3(-xScale,yScale,-1));
        line.SetPosition(2,new Vector3(xScale,yScale,-1));
        line.SetPosition(3,new Vector3(xScale,-yScale,-1));
        
    }
    public void CreateSphere()
    {
        line = GetComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.positionCount = segments + 1;
        line.loop = false;
        
        float x;
        float y;
        float z = -1f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xScale;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yScale;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }
}
