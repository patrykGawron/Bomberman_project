using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public Tilemap map;
    public PlayerMovement player;
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.IsDead)
        {
            Pause();
        }
        
    }

    void Pause()
    {
        gameOverUI.SetActive(true);
        GameIsPaused = true;
    }

    public void Retry()
    {
        gameOverUI.SetActive(false);
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Reseting");
    }
}
