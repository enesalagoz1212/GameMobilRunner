using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Start,
    Pause,
    End
}

public class GameManager : MonoBehaviour
{
    public LevelManager _levelManager;
    public GameState curruntGameState;
    private UIManager _uiManager;
    void Start()
    {
        _levelManager = GetComponent<LevelManager>();
        curruntGameState = GameState.Pause;
        _uiManager = GameObject.FindWithTag("MainUI").GetComponent<UIManager>();
    }
    public void StartGame()
    {
        curruntGameState = GameState.Start;
        _levelManager.StartLevel();

    }
    public void StartNextGame()
    {
        curruntGameState = GameState.Start;
        _levelManager.StartNextLevel();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            StartNextGame();
        }
    }
    public void EndGame()
    {
        _levelManager.EndLevel();
        _uiManager.EndLevel();

        curruntGameState = GameState.End;
        Debug.Log("Level Tamamlandý");
    }
}
