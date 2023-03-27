using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    public Button btnStart, btnNextLevel;
    public GameObject menuUI, inGameUI, endUI;
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        setBindings();
    }

    private void setBindings()
    {
        btnStart.onClick.AddListener(() =>
            {
                _gameManager.StartGame();
                menuUI.SetActive(false);
            }
        );
        btnNextLevel.onClick.AddListener(() =>
            {
                endUI.SetActive(false);
                _gameManager.StartNextGame();




            }
        );
    }

    internal void EndLevel()
    {
        endUI.SetActive(true);
    }
}

