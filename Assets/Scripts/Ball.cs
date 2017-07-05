﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    private Paddle paddle=null;
    private Vector3 paddleToBall;
    private bool click = false;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        if (paddle == null)
            print("You have to add a paddle !");
        paddleToBall = this.transform.position - paddle.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (!click)
        {
            // Lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBall;

            // Wait for the player to leftclick to launch the ball
            if (Input.GetMouseButtonDown(0))
            {
                click = true;
                print("mouse clicked, launch ball");
                this.rigidbody2D.velocity = new Vector2(2, 10);
            }
        }
        // A line to prevent the game to fall in a loop where the ball moves horizontally
        if (this.rigidbody2D.velocity.y == 0){
            this.rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Random.Range(-0.2f, 0.2f));
            print("on est censé changer sa vitesse verticale");
        }

        //Test de la ligne ci-dessus
        if (Input.GetKeyDown("space")){
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + rigidbody2D.velocity.y, 0);
        }
	}

    // Method called when the ball enter another collider
    // used here to play a boing sound
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (click){
            audio.Play();
        }
    }
}
 