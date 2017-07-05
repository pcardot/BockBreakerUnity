using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
    public bool automatedTest = false;


    private float mousePosInBlocks;

    // We keep track of the balls positions so automated playtesting work
    // For now there is no need of having an array since there can be only one ball, but when multiball it will be usefull
    private Ball[] balls;

    //TODO add a scale private float

	// Use this for initialization
	void Start () {
        balls = FindObjectsOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (automatedTest){
            AutomatedPlayTesting();
        }else{
            MoveWithMouse();    
        }
	}

    // Function that moves the paddle according to the mouse movements.
    // It restrains the paddle on the game area
    // TODO add a scale factor to the restriction so it will work with padle sizes bonuses
    void MoveWithMouse(){
        mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        mousePosInBlocks = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
        Vector3 paddlePos = new Vector3(mousePosInBlocks, this.transform.position.y, this.transform.position.z);
        this.transform.position = paddlePos;
    }

    //Function that will move the paddle automatically under the lowest ball on the screen
    void AutomatedPlayTesting(){
        //We test if there is at least one ball 
        if (balls.Length == 0){
            Debug.LogError("There is no ball detected");
        }else{ 
            // We keep track of the lowest ball to follow this one, at the end of the loop we have the lowest one
            Ball lowest = balls[0];
            foreach(Ball ball in balls){
                if (ball.transform.position.y < lowest.transform.position.y){
                    lowest = ball;
                }
            }
            // We place the paddle right the lowest ball
            transform.position = new Vector3(lowest.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
}
