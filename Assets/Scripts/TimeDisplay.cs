using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    public GameObject _gameSystem;
    public GameObject addText;
    const int _limitTime = 8;
    float _valOfSecond = 1.000f;
    float _timeElapsed;
    Text _timeText;
    int _time;

    private void Start()
    {
        _timeElapsed = 0.0f;
        _time = _limitTime;
        _timeText = GetComponent<Text>();
        _timeText.text = _time.ToString("D2");
    }

    private void Update()
    {
        if (GameSystem.isPlayGame)
        {
            _timeElapsed += Time.deltaTime;
            if (_timeElapsed >= _valOfSecond)
            {
                _timeElapsed = 0.0f;
                _time--;
                if (_time < 0)
                {
                    GameSystem.score = 0;
                    _gameSystem.SendMessage("GameOver");
                }
                _timeText.text = _time.ToString("D2");
            }
        }
    }

    int _addCount = 0;
    int _valAmount = 0;
    int n = 0;
    public void AddTime(int val)
    {
        _addCount++;
        _valAmount += val;
        if (_addCount % 3 == 0)
        {
            if (_valAmount == 0)
            {
                n = -2;
                transform.gameObject.SendMessage("PlayCheckSound", 2, SendMessageOptions.RequireReceiver);
            }
            else if (_valAmount == 1)
            {
                transform.gameObject.SendMessage("PlayCheckSound", 1, SendMessageOptions.RequireReceiver);
                n = 0;
            }
            else if (_valAmount == 2)
            {
                transform.gameObject.SendMessage("PlayCheckSound", 1, SendMessageOptions.RequireReceiver);
                n = 2;
            }
            else if (_valAmount == 3)
            {
                transform.gameObject.SendMessage("PlayCheckSound", 0, SendMessageOptions.RequireReceiver);
                n = 5;
            }
            _time += n;
            addText.SendMessage("OnAddEffect", n);
            _valAmount = 0;
        }

        if (_addCount % 10 == 0)
        {
            if (_valOfSecond > 0.05f)
            {
                _valOfSecond -= 0.05f;
            }
            else
            {
                _valOfSecond = 0.05f;
            }
        }
    }
}
