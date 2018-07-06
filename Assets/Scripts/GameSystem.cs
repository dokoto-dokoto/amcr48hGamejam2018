using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {

    public GameObject resultWindow;
    public GameObject _gaugeActivator;
    public Text _call;

    public static bool isPlayGame;
    public static bool gaugeAwakeTrigger;
    public static int score;

    const int startDelayTime = 180;
    private int count;

    private void Start()
    {
        isPlayGame = false;
        gaugeAwakeTrigger = false;
        resultWindow.SetActive(false);
        count = 0;
    }

    public void GameOver()
    {
        resultWindow.SetActive(true);
    }

    private void Update()
    {
        if(count <= startDelayTime)
        {
            count++;
        }

        if(count == 60)
        {
            _call.text = "READY";
        }
        else if(count == 120)
        {
            _call.text = "GO";
        }
        else if(count == startDelayTime)
        {
            isPlayGame = true;
            _call.text = "";
            _gaugeActivator.SendMessage("AwakeGauge");
        }

        if (gaugeAwakeTrigger)
        {
            gaugeAwakeTrigger = false;
            _gaugeActivator.SendMessage("OnActivateTrigger");
        }
    }
}
