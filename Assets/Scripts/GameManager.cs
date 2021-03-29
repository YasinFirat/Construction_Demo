using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyEvent : UnityEvent { }


public class GameManager : MonoBehaviour
{
    public LevelController levelController;
    public TouchManager touchManager;
    public MeshController meshController;
    public MeshInfo meshInfo;
    
    public ParticleSystem particleSystem;

    public MyEvent win;
    public MyEvent lose;
   

  
   


}
