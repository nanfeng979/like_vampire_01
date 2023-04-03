using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Playing,
    GameOver
}

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    private GameState gameState = GameState.Playing;

    void Start()
    {
        instance = this;
    }

    void Update() {
        if(gameState == GameState.Playing) {
            Time.timeScale = 1;
        } else if(gameState == GameState.GameOver) {
            Time.timeScale = 0;
        }
    }

    public GameState GetGameState() {
        return gameState;
    }

    public void SetGameState(GameState state) {
        gameState = state;
    }
}
