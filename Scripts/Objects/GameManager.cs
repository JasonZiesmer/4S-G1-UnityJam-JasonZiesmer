using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public Vector2 lastCheckPoint;

    public Vector2 enemyStation;

    private void Awake()
    {
        //obj doesnt get destroyed if the scene gets reloaded
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        //makes sure only 1 gamemanager exist
        else
        {
            Destroy(gameObject);
        }
    }
}
