using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAddDisplay : MonoBehaviour
{
    const float interval = 0.6f;
    public Vector3 outOFRangePos = new Vector3(35, 80, 0);
    public Vector3 spawnPos = new Vector3(35, -10, 0);
    public GameObject gaugeSpawner;

    Text text;
    float _timeElapsed;
    bool _timeAddTrigger;

    private void Start()
    {
        text = GetComponent<Text>();
        _timeAddTrigger = false;
        _timeElapsed = 0.0f;
    }

    void Update()
    {
        if (_timeAddTrigger)
        {
            _timeElapsed += Time.deltaTime;
            text.transform.localPosition += Vector3.up;
        }

        if (_timeElapsed > interval)
        {
            text.transform.localPosition = outOFRangePos;
            _timeElapsed = 0.0f;
            _timeAddTrigger = false;
            gaugeSpawner.SendMessage("OnActivateTrigger");
        }
    }

    public void OnAddEffect(int n)
    {
        _timeAddTrigger = true;
        if (n >= 0)
        {
            text.text = "+" + n.ToString();
        }
        else
        {
            text.text = n.ToString();
        }
        text.transform.localPosition = spawnPos;
    }
}
