using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeSetter : MonoBehaviour {

    List<RectTransform> _uiList = new List<RectTransform>();

	void Start () {
        var parentTransform = GetComponent<Transform>();
        foreach(RectTransform item in parentTransform.GetComponentInChildren<RectTransform>())
        {
            _uiList.Add(item);
            //item.gameObject.SetActive(false);
        }
    }

    int _activeUiCount = 0;
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _uiList[_activeUiCount].gameObject.SetActive(true);
            _activeUiCount++;
        }
	}
}
