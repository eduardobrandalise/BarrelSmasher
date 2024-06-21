using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Menu,
    Playing,
    GameOver
}

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    private GameState _gameState = GameState.Menu;

    private void Awake()
    {
        if (_instance != null && _instance != this) { Destroy(gameObject); }
        else { _instance = this; }
    }

    public GameState GameState
    {
        get { return _gameState; }
        private set { _gameState = value; }
    }

    private void Start()
    {
        _gameState = GameState.Menu;
    }

    public void StartGame()
    {
        _gameState = GameState.Playing;
    }

    public void SetGameOver()
    {
        _gameState = GameState.GameOver;
    }

    void OnDestroy()
    {
        if (_instance == this) { _instance = null; }
    }
}
