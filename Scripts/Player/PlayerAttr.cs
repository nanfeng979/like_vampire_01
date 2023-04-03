using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    Health,
    Die
}

public class PlayerAttr : MonoBehaviour
{
    // private int maxHp = 10;
    private int currentHp = 10;
    // private int attack = 2;
    // private int attackSpeed = 1;

    private PlayerState playerstate;

    void Start() {
        playerstate = PlayerState.Health;
    }

    public void Attacked(int damage) {
        if(GameManager.instance.GetGameState() != GameState.Playing) {
            return;            
        }
        if(playerstate == PlayerState.Die) {
            return;
        }

        currentHp -= damage;
        CheckDie();

        Debug.Log(currentHp);
    }

    private void CheckDie() {
        if (currentHp <= 0) {
            Die();
        }
    }

    private void Die() {
        GameManager.instance.SetGameState(GameState.GameOver);
        playerstate = PlayerState.Die;
    }
    
}
