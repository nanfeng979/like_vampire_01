using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerMoveSpeed = 3.0f;
    private float inputX;
    private float inputY;

    void Update()
    {
        PlayerMoving();
    }

    private void PlayerMoving() {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(inputX, inputY);

        if(dir != Vector2.zero) {
            transform.Translate(dir * PlayerMoveSpeed * Time.deltaTime);
        }
    }
}
