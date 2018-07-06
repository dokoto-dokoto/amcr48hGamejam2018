using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle_fillGaugeControl : MonoBehaviour
{
    public Image check;
    public Text timeText;

    Transform _transform;
    bool _stopFlag;

    private void Start()
    {
        check.fillAmount = 0.0f;
        _transform = GetComponent<Transform>();
        _transform.localScale = Vector3.zero;
        _stopFlag = false;
    }

    float _scale = 0.0f;
    public void ResetFlag()
    {
        check.fillAmount = 0.0f;
        _stopFlag = false;
        _scale = 0.0f;
    }

    float _updateScale = 0.025f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_stopFlag)
        {
            _stopFlag = true;
            ClearCheck(_scale * 100);
        }

        if (!_stopFlag)
        {
            _scale += _updateScale + 0.001f * (GameSystem.score / 5);
            if (_scale >= 1.0f)
            {
                _scale = 0.0f;
            }
            _transform.localScale = _scale * Vector3.one;
        }
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
