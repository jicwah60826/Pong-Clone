using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    // This script is loaded onto the ball to determine what the ball has collided with.


    // get reference to the BallMovement script that is attached to the ball

    public BallMovement ballMovement;

    public ScoreController scoreController;

    void BounceFromRacket(Collision2D other)
    {
        // get ball position
        Vector3 ballPosition = transform.position;


        // get the position of the object that the ball colided with

        Vector3 racketPosition = other.gameObject.transform.position;

        // get the bounds height of the object the ball collided with
        float racketHeight = other.collider.bounds.size.y;

        float x;

        if (other.gameObject.name == "Racket Left")
        {
            Debug.Log("racket left was hit");
            x = 1; //fly towards the right
        }
        else
        {
            x = -1; //fly towards the left
        }

        float y = (ballPosition.y - racketPosition.y / racketHeight);

        ballMovement.IncreaseHitCounter();

        ballMovement.MoveBall(new Vector2(x, y));

    }




    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Racket Left" || other.gameObject.name == "Racket Right")
        {
            BounceFromRacket(other);
        }

        else if (other.gameObject.name == "Left Wall")
        {
            Debug.Log("Collision with Left wall");

            scoreController.GoalPlayer2();
            StartCoroutine(ballMovement.StartBallCo(true));
        }

        else if (other.gameObject.name == "Right Wall")
        {
            Debug.Log("Collision with Right wall");

            scoreController.GoalPlayer1();
            StartCoroutine(ballMovement.StartBallCo(false));
        }
    }




}
