using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Fields
    private static bool isGamePaused = false;
    private static float gameSpeed = 1;
    #endregion

    #region Getter Setters
    public static bool IsGamePaused { get { return isGamePaused; } set { isGamePaused = value; } }

    public static float GameSpeed { get { return gameSpeed; } set { gameSpeed = value; } }
    #endregion

    #region Update
    private void Update()
    {
        //Update TimeScale every update cycle
        Time.timeScale = gameSpeed;
    }
    #endregion

    #region UI Events Subscribers
    private void Start()
    {
        
    }
    #endregion

    #region Methods setting Game Status
    public void PauseGame(bool Paused)
    {
        if (Paused)
        {
            Time.timeScale = 0;
            IsGamePaused = true;
        }
        else
        {
            IsGamePaused = false;
            Time.timeScale = GameSpeed;
        }
    }
    public void SetSpeed(float speed)
    {
        GameSpeed = speed;
    }
    #endregion
}

