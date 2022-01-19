using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject glassball;
    public GameObject player;

    public Sprite heart_full;
    public Sprite heart_empty;

    public GameObject hearts;
    public GameObject gameOver;

    public Text text_MaxScore;
    public Text text_NowScore;

    public float spawnPeriod = 1f;

    public int Health {
        private set {
            health = value;
        }
        get {
            return health;
        }
    }

    private bool isNewBest = false;

    private int health = 3;

    private int maxScore = 0;
    private int nowScore = 0;

    private float nowPerioid = 0f;

    private void Start() {
        onInitGame();
    }

    private void Update() {
        if (health <= 0) {
            if (health == 0) {
                Debug.Log("[게임매니저] 게임 오버! 플레이어가 모든 목숨을 잃어 게임이 종료되었습니다.");
                Debug.Log("[게임매니저] 마지막 시점의 점수는 " + nowScore + "점입니다.");

                gameOver.SetActive(true);
                health--;
            }
            else {
                return;
            }
        }

        if (nowPerioid >= spawnPeriod) {
            nowPerioid = 0f;

            float random_x = Random.Range(-9f, 9f);

            Instantiate(glassball, new Vector3(random_x, 6f, 0f), Quaternion.identity);
        }

        nowPerioid += Time.deltaTime;

        text_NowScore.text = nowScore.ToString() + "점";

        if (nowScore >= maxScore) {
            if (maxScore > 0 && !isNewBest) {
                nowScore += 30;
                isNewBest = true;

                text_NowScore.gameObject.SetActive(false);
            }

            maxScore = nowScore;
            text_MaxScore.text = "최고 " + maxScore.ToString() + "점";
        }
    }

    private void onInitGame() {
        nowScore = 0;

        if (maxScore > 0) {
            text_NowScore.gameObject.SetActive(true);
        }

        text_NowScore.text = nowScore.ToString() + "점";
        text_MaxScore.text = "최고 " + maxScore.ToString() + "점";

        player.GetComponent<SpriteRenderer>().color = Color.white;

        for (int i = 0; i < 3; i++) {
            hearts.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = heart_full;
        }

        health = 3;

        isNewBest = false;
    }

    public void onPlayerAvoid() {
        nowScore += 20;
    }

    public void onPlayerHit() {
        if (health <= 0) {
            return;
        }
        else {
            health--;
            Debug.Log("[게임매니저] 플레이어가 유리공에 맞아 체력을 1 차감합니다. 남은 체력 : " + health);

            for (int i = 2; i >= 0; i--) {
                Image temp = hearts.transform.GetChild(i).GetComponent<Image>();

                if (temp.sprite == heart_full) {
                    temp.sprite = heart_empty;
                    break;
                }
            }
        }
    }

    public void onRestartGame() {
        onInitGame();
        gameOver.SetActive(false);
    }
}
