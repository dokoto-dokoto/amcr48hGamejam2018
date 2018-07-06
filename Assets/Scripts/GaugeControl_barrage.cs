using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeControl_barrage : MonoBehaviour
{

    Slider _slider;
    bool _stopFlag;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _stopFlag = false;
    }

    float _barrage_val = 0;
    float _barrage_val_vel = -0.001f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !_stopFlag)
        {
            _barrage_val += 0.025f;
            _barrage_val_vel = 0.0f;
        }
        else if (_stopFlag)
        {
            _barrage_val_vel = 0;
        }
        else
        {
            _barrage_val_vel -= 0.0001f;
        }

        _barrage_val += _barrage_val_vel;
        if (_barrage_val >= 1)
        {
            _barrage_val = 1;
            _stopFlag = true;
        }
        else if (_barrage_val <= 0)
        {
            _barrage_val = 0;
        }

        _slider.value = _barrage_val;
    }
}
