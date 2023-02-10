using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Player player;

    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {


        if (player.GetIsDead())
        {
            GameOver();
        }
        else
        {
            GamePlay();
        }

    }

    void GameOver()
    {

    }

    void GamePlay()
    {
        SetTimer();
    }

    void DebugList()
    {
        Debug.Log(timer);
    }


    void SetTimer()
    {
        timer = Time.deltaTime;
    }
}
