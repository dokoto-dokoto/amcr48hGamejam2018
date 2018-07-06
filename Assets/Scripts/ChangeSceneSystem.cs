using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneSystem : MonoBehaviour {
    public static int _gameLevel;

    public void SceneChage(string sceneTitle)
    {
        SceneManager.LoadScene(sceneTitle);
    }

    public void SceneChangeToGame(int level)
    {
        _gameLevel = level;
        SceneManager.LoadScene("GameScene");
    }

    public void SceneChangeToRetryGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SceneChangeToNextLevelGame()
    {
        _gameLevel++;
        SceneManager.LoadScene("GameScene");
    }
}
