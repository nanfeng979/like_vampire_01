using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
    Idle,
    Chasing,
    AttackCD
}

public class EnemyController : MonoBehaviour
{
    public float EnemyMoveSpeed = 2.0f;

    public float AttackSpeed = 1.0f;

    private Transform Player;
    private float AttackSpeedTimer = 1.0f;
    private float AttackRange;
    private bool CanAttack = true;
    private bool InTriggerStay = false;
    private Collider2D MyCollider;

    // private EnemyState enemystate = EnemyState.Idle;
    private Vector2 MySize;

    void Start() {
        MySize = GetComponent<SpriteRenderer>().size;
        Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, Player.position) > MySize.magnitude / 2) {
            ChasingToPlayer();
        }

        if(AttackSpeedTimer < AttackSpeed) {
            AttackSpeedTimer += Time.deltaTime;
        } else {
            CanAttack = true;
        }
        
        MyTriggerStay2D();
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if(!InTriggerStay && CanAttack) {
            AttackPlayer(other.gameObject);
        }

        InTriggerStay = true;
        MyCollider = other;
    }

    private void MyTriggerStay2D() {
        if(InTriggerStay && CanAttack) {
            AttackPlayer(MyCollider.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        InTriggerStay = false;
    }

    private void ChasingToPlayer() {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, EnemyMoveSpeed * Time.deltaTime);
    }

    private void AttackPlayer(GameObject obj) {
        CanAttack = false;
        AttackSpeedTimer = 0.0f;
        obj.GetComponent<PlayerAttr>().Attacked(1);
    }

}
