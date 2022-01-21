using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private SpriteRenderer render;

    private GameManager manager;

    private void Start() {
        render = GetComponent<SpriteRenderer>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        render.color = Color.white;

        transform.position = new Vector3(0f, -3f, 0f);
    }

    private void Update() {
        if (manager.Health <= 0) {
            render.color = new Color(0.3921569f, 0.3921569f, 0.3921569f);
            return;
        }
        else {
            if (Input.GetKeyDown(KeyCode.A)) {
                moveLeft();
            }

            if (Input.GetKeyDown(KeyCode.D)) {
                moveRight();
            }
        }
    }

    public void moveLeft() {
        if (manager.Health <= 0) {
            return;
        }

        if (transform.position.x >= -9.6f) {
            render.flipX = false;
            transform.Translate(-1f, 0f, 0f);
        }
        else {
            transform.position = new Vector3(-9.6f, -3f, 0f);
        }
    }

    public void moveRight() {
        if (manager.Health <= 0) {
            return;
        }

        if (transform.position.x <= 9.4f) {
            render.flipX = true;
            transform.Translate(1f, 0f, 0f);
        }
        else {
            transform.position = new Vector3(9.4f, -3f, 0f);
        }
    }
}
