using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("No Game Manager set");

            return _instance;
        }
    }

    public ScoreManager scoreManager;
    public GameStateManager gameStateManager;
    public LifeManager lifeManager;
    public RootController rootManager;
    public LevelManager levelManager;
    public SongManager songManager;

    private void Awake()
    {
        _instance = this;

        scoreManager = GetComponent<ScoreManager>();
        lifeManager = GetComponent<LifeManager>();
        gameStateManager = GetComponent<GameStateManager>();
    }
}
