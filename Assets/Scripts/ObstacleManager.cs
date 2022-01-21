using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {
    private GameManager manager;

    private void Start() {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate() {
        if (transform.position.y <= -5.75f) {
            manager.onPlayerAvoid();
            Destroy(gameObject);
        }
        else {
            transform.Translate(0f, -0.175f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Debug.LogWarning("[유리공] 유리공이 플레이어와 부딫혔습니다!");
            manager.onPlayerHit();

            Destroy(gameObject);
        }
    }
}
