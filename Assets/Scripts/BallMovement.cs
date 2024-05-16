using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maxExtraSpeedHit;
    public float startWaitTime;

    public float ballStartOffset;

    int hitcounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartBallCo());
    }

    private void PositionBall(bool isStartingPlayer1)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (isStartingPlayer1)
        {
            gameObject.transform.localPosition = new Vector3((ballStartOffset*-1), 0, 0);
        }
        else
        {
            gameObject.transform.localPosition = new Vector3(ballStartOffset, 0, 0);
        }
    }

    public IEnumerator StartBallCo(bool isStartingPlayer1 = true)
    {

        PositionBall(isStartingPlayer1);

        // reset hitcounter
        hitcounter = 0;

        // wait 2 seconds
        yield return new WaitForSeconds(startWaitTime);

        if (isStartingPlayer1)
        {
            MoveBall(new Vector2(-1, 0));
            Debug.Log("zz1");
        }
        else
        {
            MoveBall(new Vector2(1, 0));
            Debug.Log("zz2");
        }
    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;

        float speed = movementSpeed + hitcounter * extraSpeedPerHit;
        Debug.Log("Moveball speed = " + speed);
        //add force to the RB

        Rigidbody2D theRB = gameObject.GetComponent<Rigidbody2D>();

        theRB.velocity = dir * speed;
    }

    public void IncreaseHitCounter()
    {
        Debug.Log("IncreaseHitCounter invoked");

        if (hitcounter * extraSpeedPerHit <= maxExtraSpeedHit)
        {
            hitcounter++;
        }
    }
}
