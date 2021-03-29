using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDirection : MonoBehaviour
{
    public Transform console;
    public  float maxfowardTurn=15;
    public  float maxLeftTurn=15;
    public  float maxRightTurn=15;
    public  float maxBackTurn=15;
    private Vector3Int rotate;
    private Vector3 keepRotate;
    public VariableJoystick variableJoystick;


    #region bool degerler, her ihtimale karsi olusturuldu
    public bool isFoward
    {
        get
        {
            return rotate.z == 1;
        }
    }
    public bool isBack
    {
        get
        {
            return rotate.z == -1;
        }
    }
    public bool isRight
    {
        get
        {
            return rotate.x == 1;
        }
    }
    public bool isLeft
    {
        get
        {
            return rotate.x == -1;
        }
    }
    #endregion
    public float GetZ
    {
        get
        {
            return console.localRotation.z*360/Mathf.PI/maxfowardTurn;
        }
    }
    public float GetX
    {
        get
        {
            return console.localRotation.x*360/Mathf.PI/maxRightTurn;
        }
    }
    
    public ControllerDirection Turn()
    {
        console.localEulerAngles = new Vector3(maxfowardTurn * variableJoystick.Vertical,0, -maxRightTurn * variableJoystick.Horizontal);
        return this;
    }

    
    

   
}
