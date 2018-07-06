using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GaugeActivator : MonoBehaviour
{
    public int uiNum;
    public List<GameObject> uiList;

    void Start()
    {
        foreach(GameObject ui in uiList)
        {
            ui.SetActive(false);
        }
    }

    int _uiCount = 0;
    
    public void AwakeGauge()
    {
        if(_uiCount == 3)
        {
            _uiCount++;
            GameSystem.score++;
            return;
        }
        else if(_uiCount > uiNum)
        {
            _uiCount = 0;
            
            foreach (GameObject u in uiList.Where(u => u.activeInHierarchy))
            {
                u.gameObject.SendMessage("ResetFlag", SendMessageOptions.RequireReceiver);
                u.gameObject.SetActive(false);
            }
        }
        int index = 0;
        switch (ChangeSceneSystem._gameLevel)
        {
            case 1:
                index = 0;
                break;
            case 2:
                index = 1;
                break;
            case 3:
                index = Random.Range(0, uiNum - 1);
                break;
            case 4:
                index = 2;
                break;
            case 5:
                index = Random.Range(0, uiNum);
                break;
        }
        uiList[uiNum * _uiCount + index].gameObject.SetActive(true);
        _uiCount++;
    }

    public void OnActivateTrigger()
    {
        if (GameSystem.isPlayGame)
        {
            AwakeGauge();
        }
    }
}
