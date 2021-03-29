using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Tıklanma olayında nesne aşağı düşecek.
/// </summary>
public class TouchManager : ConstructionGame
{
    private LevelController levelController;
    float timer;

    private void Start()
    {
        levelController = gameManager.levelController;
        timer = 0;
    }

    private void Update()
    {
       
        if (!levelController.Kinematic)
        {
          //  Debug.Log(levelController.Velocity.magnitude);
            if (levelController.Velocity.magnitude<=.1f)
            {
                timer += Time.deltaTime;
                levelController.Winner(timer);
            }
           
        }
       
        if (Input.touchCount > 0)
        {
            Touch touch =Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (FindTouchObject(touch.position).CompareTag("Button"))
                    {
                        levelController.Kinematic = false;
                       
                    }
                  
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    break;
            }
        }
    }
    public GameObject FindTouchObject(Vector3 touchPosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        if (Physics.Raycast(ray, out hit))
        {
           
            return hit.transform.gameObject;
        }
        return this.gameObject;
        
        
    }

    private void OnMouseUp()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
