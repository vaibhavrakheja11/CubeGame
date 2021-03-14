using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_scoreText;

    const string GameScene = "GameScene";

    const string UIScene = "UIScene";
   
    void Start()
    {
        GameController.IncreaseScore += DisplayScroe;
    }

    void DisplayScroe(string score)
    {
         m_scoreText.text = score.ToString();
    }

    void OnDestroy()
    {
        GameController.IncreaseScore -= DisplayScroe;
    }


    public void HandlePlayButton()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void HandleExitButton()
    {
        Application.Quit();
    }

    public void HandleBackButton()
    {
        SceneManager.LoadScene(UIScene);
    }
    
}
