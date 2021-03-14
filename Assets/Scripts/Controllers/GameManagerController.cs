using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{

    public PanelManager uiManager;

    public GameController gameController;


    #region SINGLETON PATTERN
    private static GameManagerController _instance;
    public static GameManagerController Instance
    {
        get {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManagerController>();
            }
        
            return _instance;
        }
    }
    #endregion
}
