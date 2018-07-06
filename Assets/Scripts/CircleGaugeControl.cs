using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleGaugeControl : MonoBehaviour
{
    public Image check;
    public Text timeText;
    Image _img;
    bool _stopFlag;

    void Start()
    {
        check.fillAmount = 0.0f;
        _img = GetComponent<Image>();
        _img.fillAmount = 0;
        _stopFlag = false;
    }

    float _fillAmount;
    public void ResetFlag()
    {
        check.fillAmount = 0.0f;
        _stopFlag = false;
        _fillAmount = 0.0f;
    }

    float _updateAmount = 0.01f;
    bool flag;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_stopFlag)
        {
            _stopFlag = true;
            ClearCheck(_fillAmount * 100);
        }

        if (!_stopFlag)
        {
            if (flag)
            {
                _fillAmount -= _updateAmount + 0.002f * (GameSystem.score / 5);
            }
            else
            {
                _fillAmount += _updateAmount + 0.002f * (GameSystem.score / 5);
            }

            if (_fillAmount > 0.75f)
            {
                flag = true;
                _fillAmount = 0.75f;
            }
            else if (_fillAmount < 0.0f)
            {
                flag = false;
                _fillAmount = 0.0f;
            }
        }

        _img.fillAmount = _fillAmount;
    }

    float _border = 60;
    void ClearCheck(float value)
    {
        if (value >= _border * 0.75)
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
