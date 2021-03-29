using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : ConstructionGame
{
    public GameObject stone;
    public GameObject nest;
    public GameObject diggingTool;
    public int starAmount;
    private Rigidbody rb;
    public float waitWinnerCheck = 1;
    [Header("Draw Nest")]
    public MyEvent drawNest;
    public float timer;

   
    public bool Kinematic
    {
        get
        {
            return rb.isKinematic;
        }
        set
        {
            rb.isKinematic = value;
        }

    }
    public Vector3 Velocity
    {
        get
        {
            return rb.velocity;
        }
    }

    public LevelController Winner(float time)
    {
        Debug.Log("Distance: "+Vector2.Distance(stone.transform.position, nest.transform.position));
       
        if (Vector2.Distance(stone.transform.position, nest.transform.position) <= .2f && time >= waitWinnerCheck)
        {
            gameManager.win?.Invoke();
        }
        else if(time >= waitWinnerCheck)
        {
            gameManager.lose?.Invoke();
        }
        return this;
    }

    public void Start()
    {
      
        rb = stone.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        nest.transform.localScale = stone.transform.localScale; 
        drawNest?.Invoke();
    }

   

}
