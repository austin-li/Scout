using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour {

    // Use this for initialization
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Text text;

    private int logo;
    private bool win;
    private bool translated;

    public float timer = 6;
    public float sceneTimer = 2;
    void Start() {
        transform.Translate(Random.Range(-20, 20), 0, 0);
        logo = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[logo];

        win = false;
        translated = false;
    }

    // Update is called once per frame
    void Update() {
        if (timer > 0) {
            if (Input.GetKey("left")) {
                transform.Translate(-0.15f, 0, 0);
            }

            if (transform.position.x < 161.5f) {
                transform.Translate(202.7f - 161.5f, 0, 0);
            }

            if (Input.GetKey("right")) {
                transform.Translate(0.15f, 0, 0);
            }

            if (transform.position.x > 215.8f) {
                transform.Translate(174.6f - 215.8f, 0, 0);
            }

            if (Input.GetKeyDown("space")) {
                float x = transform.position.x;
                if (logo == 0 && (Mathf.Abs(x - 174.5f) < 4 || Mathf.Abs(x - 215.5f) < 4) ||
                    logo == 1 && Mathf.Abs(x - 194.3f) < 4 ||
                    logo == 2 && Mathf.Abs(x - 184.1f) < 4 ||
                    logo == 3 && (Mathf.Abs(x - 163.7f) < 4 || Mathf.Abs(x - 204.8f) < 4)) {
                    win = true;
                } else {
                    timer = 0;
                }
            }
            timer -= Time.deltaTime;
        }

        if (timer < 0 || win) {
            if (win) {
                timer = 0;
                text.text = "O";
                text.color = Color.green;
                if (!translated) {
                    text.transform.Translate(-0.35f, 0, 0);
                    translated = true;
                }
            }
            text.enabled = true;
            sceneTimer -= Time.deltaTime;
        }

        if (sceneTimer < 0) {
            LoadScene("a");//replace with transition scene
        }
	}

    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }
}