using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeGenerator : MonoBehaviour
{

    public Vector3[] gaugePosition;
    public List<GameObject> uiList;

    int _gaugeCount = 0;
    public void GaugeAwake()
    {
        int gaugeNum = uiList.Count;
        int index = Random.Range(0, gaugeNum);
        var gauge = uiList[index];
        gauge.GetComponent<RectTransform>().localPosition = gaugePosition[_gaugeCount];
        Debug.Log(_gaugeCount);
        Debug.Log(gauge.GetComponent<RectTransform>().localPosition);
        Instantiate(gauge).transform.SetParent(transform,false);


        _gaugeCount++;
        if (_gaugeCount >= 3)
        {
            _gaugeCount = 0;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GaugeAwake();
        }
    }
}
