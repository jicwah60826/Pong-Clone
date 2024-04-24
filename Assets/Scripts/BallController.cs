using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maxExtraSpeedHit;
    public float startWaitTime;

    int hitcounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartBallCo());
    }


    public IEnumerator StartBallCo(bool isStartingPlayer1 = true)
    {
     // reset hitcounter
        this.hitcounter = 0;

        // wait 2 seconds
        yield return new WaitForSeconds(this.startWaitTime);

        if (isStartingPlayer1)
        {
            this.MoveBall(new Vector2(-1, 0));
            Debug.Log("zz1");
        }

        else
        {
            this.MoveBall(new Vector2(1, 0));
            Debug.Log("zz2");

        }
    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;

        float speed = this.movementSpeed + this.hitcounter * this.extraSpeedPerHit;

        //add force to the RB

        Rigidbody2D theRB = this.gameObject.GetComponent<Rigidbody2D>();

        theRB.velocity = dir * speed;

    }

    public void IncreaseHitCounter()
    {
            if(this.hitcounter *this.extraSpeedPerHit <= this.maxExtraSpeedHit)
        {
            hitcounter++;
        }
    }
}
