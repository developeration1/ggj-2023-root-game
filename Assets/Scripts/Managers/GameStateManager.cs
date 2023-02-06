using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**
 * Has the current game status and methods to update it.
 */
public class GameStateManager : MonoBehaviour
{
    public enum GameState { NonPaused, GameOver, Won, Paused, Started };

    public GameState currentState;

    public event Action<GameState> GameStateChanged = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.NonPaused;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel()
    {
        currentState = GameState.Started;
        GameStateChanged.Invoke(GameState.Started);
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        GameStateChanged.Invoke(GameState.GameOver);
    }

    public void Win()
    {
        currentState = GameState.Won;
        GameStateChanged.Invoke(GameState.Won);
    }

    public void Pause()
    {
        currentState = GameState.Paused;
        GameStateChanged.Invoke(GameState.Paused);
    }

    public void Resume()
    {
        currentState = GameState.Started;
        GameStateChanged.Invoke(GameState.Started);
    }
}
