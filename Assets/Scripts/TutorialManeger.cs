using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManeger : MonoBehaviour {

    [SerializeField]
    private List<string> tutorialTexts;

    [SerializeField]
    private Text tutorialText;

    int tutorialNum;

    private void Start()
    {
        tutorialNum = 0;
        tutorialText.text = tutorialTexts[tutorialNum];
    }

    public void OnNextTutorial()
    {
        tutorialNum++;
        tutorialText.text = tutorialTexts[tutorialNum];
    }
}
