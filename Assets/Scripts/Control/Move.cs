using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public ControllerDirection controllerDirection;
    public float speedX=5;
    public float speedY=2;
    
    private float x;
    private float y;

   

    private void FixedUpdate()
    {
       
        controllerDirection.Turn();
       
        x = -controllerDirection.GetZ* speedX * Time.deltaTime;
        y =  controllerDirection.GetX * speedY * Time.deltaTime;

      //  transform.position += new Vector3(x, y, 0);
        transform.Translate(new Vector3(x, y, 0));
    }
}
