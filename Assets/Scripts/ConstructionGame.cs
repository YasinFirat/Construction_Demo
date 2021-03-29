using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConstructionGame : MonoBehaviour
{
    private GameManager _gameManager;

    public GameManager gameManager
    {
        get
        {
            if (_gameManager == null)
            {
                _gameManager = FindObjectOfType<GameManager>();
                return _gameManager;
            }
            return _gameManager;
        }
    }
}
