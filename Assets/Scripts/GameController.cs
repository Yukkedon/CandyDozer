using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Player      player;
    [SerializeField] TextMeshProUGUI timerText;

    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "00:00:00";
        timer = 0;
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
        AddTimer();
    }

    


    void AddTimer()
    {
        timer += Time.deltaTime;
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", (int)(timer / 60), (int)(timer % 60), (int)((timer * 100) % 100));
    }


    public Transform GetPlayerTransfrom()
    {
        return player.transform;
    }
}
