using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TitleSystem : MonoBehaviour
{
    public GameObject[] UIList;

    private void Start()
    {
        UIList[1].SetActive(false);
        UIList[2].SetActive(false);
    }

    public void SwitchUI(int id)
    {
        foreach(GameObject ui in UIList.Where(u => u.activeInHierarchy))
        {
            ui.SetActive(false);
        }
        UIList[id].SetActive(true);
    }
}
