using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    //Variables with editor access
    [SerializeField] float minComponentSpeed = 0.2f;

    //Variables
    int collidedWithZero;

    // References 
    Ball ball;
    Vector2 ballSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();  
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if ( other.gameObject.name == "Ball")
        {
            ballSpeed = ball.GetBallSpeed();
            if (Mathf.Abs(ballSpeed.x) <= minComponentSpeed || Mathf.Abs(ballSpeed.y) <= minComponentSpeed)
            {
                collidedWithZero += 1;
            }
            else
            {
                collidedWithZero = 0;
            }

            if (collidedWithZero >= 2)
            {
                collidedWithZero = 0;
                ball.ResetBall();
            }
        }
    }
    
}
