using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeControl : MonoBehaviour
{
    public Image check;
    public Text timeText;

    Slider _slider;
    bool _stopFlag;

    private void Start()
    {
        check.fillAmount = 0.0f;
        _slider = GetComponent<Slider>();
        _stopFlag = false;
    }

    float _val = 0;
    public void ResetFlag()
    {
        check.fillAmount = 0.0f;
        _stopFlag = false;
        _val = 0;
    }

    float _updateVal = 0.05f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_stopFlag)
        {
            _stopFlag = true;
            ClearCheck(_val * 100);
        }

        if (!_stopFlag)
        {
            _val += _updateVal + 0.01f * (GameSystem.score / 5);
        }

        if (_val > 1)
        {
            _val = 0;
        }

        _slider.value = _val;
    }

    float _border = 60;
    void ClearCheck(float value)
    {
        if (value >= _border)
        {
            check.fillAmount = 1.0f;
            timeText.SendMessage("AddTime", 1, SendMessageOptions.RequireReceiver);
        }
        else
        {
            timeText.SendMessage("AddTime", 0, SendMessageOptions.RequireReceiver);
        }
        GameSystem.gaugeAwakeTrigger = true;
    }
}
