using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    // Use this for initialization
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int logo;
    private float timer;
    void Start () {
        transform.Translate(Random.Range(-20, 20), 0, 0);
        logo = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[logo];
        timer = 6;
    }
	
	// Update is called once per frame
	void Update () {
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
                if (logo == 0 && (Mathf.Abs(x - 174.5f) < 4 || Mathf.Abs(x - 215.5f) < 4)) {
                    print("0");
                }
                else if (logo == 1 && Mathf.Abs(x - 194.3f) < 4) {
                    print("1");
                }
                else if (logo == 2 && Mathf.Abs(x - 184.1f) < 4) {
                    print("2");
                }
                else if (logo == 3 && (Mathf.Abs(x - 163.7f) < 4 || Mathf.Abs(x - 204.8f) < 4)) {
                    print("3");
                }
                else {
                    print("EFAH");
                }
            }
            timer -= Time.deltaTime;
        }
	}
}