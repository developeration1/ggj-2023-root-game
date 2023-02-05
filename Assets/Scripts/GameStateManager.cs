using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    enum GameState { Playing, GameOver, Won, Paused };

    GameState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
    }

    public void Win()
    {
        currentState = GameState.Won;
    }

    public void Pause()
    {
        currentState = GameState.Paused;
    }

    public void Resume()
    {
        currentState = GameState.Playing;
    }
}
