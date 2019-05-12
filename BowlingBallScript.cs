using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the bowling ball
public class BowlingBallScript : MonoBehaviour
{

    public GameObject startPos;
    public bool ballStuck = false;
    public float stuckTimer = 0;
    public AudioSource ballSFX;

    // Gets the Ball's audio component on play
    void Start()
    {
        ballSFX = gameObject.GetComponent<AudioSource>(); 
    }

    // Resets the Ball's position and velocity
    private void ResetBallPositionVelocity()
    {
        this.gameObject.transform.position = startPos.transform.position;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    // If the Ball goes in the gutter or behind the pins reset the ball
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BowlingDeadZone")
        {
            if (BowlingGameScript.instance.colliding == false)
            {
                StartCoroutine(BallReset());
            }
        }

        // If the Ball gets out of bounds, reset it's position at its origin and reset its velocity
        if (other.gameObject.tag == "BowlingOutOfBounds")
        {
            ResetBallPositionVelocity();
        }
    }

    // If the ball gets trapped in the lane, reset it after a time limit
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BallStuck")
        {
            // The amount of time the ball can be stuck before resetting
            stuckTimer += 1 * Time.deltaTime;
            if(stuckTimer >= 20)
            {
                ResetBallPositionVelocity();
            }
        }
    }

    // Rests the timer when the stuck ball is reset
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BallStuck")
        {
            stuckTimer = 0;
        }
    }

    // Play a sound effect on collision
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            ballSFX.Play();
        }
    }

    // After an amount of time, reset the ball, set collisions to false and increase the bowling throw the player is on
    public IEnumerator BallReset()
    {
        BowlingGameScript.instance.colliding = true;
        yield return new WaitForSeconds(5);
        ResetBallPositionVelocity();
        BowlingGameScript.instance.colliding = false;
        BowlingGameScript.instance.ballNumber++;
        yield break;
    }

}
