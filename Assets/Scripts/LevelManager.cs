using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Level[] levels;

    public int currentLevel;
    private Player _player;
    private Vector3 playerDefaultPosition;
    void Start()
    {
        Debug.Log(_player);
        _player  = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerDefaultPosition = _player.transform.position;
    }
    public void StartLevel()
    {

        levels[currentLevel].gameObject.SetActive(true);
       _player.transform.position = playerDefaultPosition;
    }
    public void StartNextLevel()
    {
        levels[currentLevel].gameObject.SetActive(false);
        currentLevel++;
        StartLevel();
    }
    public void EndLevel()
    {

    }
    private void Update()
    {
       
    }

}
