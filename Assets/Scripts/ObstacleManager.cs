using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {
    private GameManager manager;

    private void Start() {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update() {
        if (transform.position.y <= -5.75f) {
            manager.onPlayerAvoid();
            Destroy(gameObject);
        }
        else {
            transform.Translate(0f, -0.05f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Debug.LogWarning("[������] �������� �÷��̾�� �΋H�����ϴ�!");
            manager.onPlayerHit();

            Destroy(gameObject);
        }
    }
}
