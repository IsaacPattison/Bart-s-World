using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the buttons that start the arcade games
public class BowlingButtonScript : MonoBehaviour {

    // References for the Bowling game
    public GameObject bowlingManager;
    public BowlingGameScript bowlingManagerScript;

    // References for the Basketball game
    public GameObject bBallManager;
    public BasketballManager bBallManagerScript;

    // References for the Skeeball game
    public GameObject skeeBallManager;
    public SkeeballManagerScript skeeBallManagerScript;
    public GameObject skeeBallButton;


    // Get references to arcade game scripts on play
    void Start ()
    {
        bowlingManagerScript = bowlingManager.GetComponent<BowlingGameScript>();
        bBallManagerScript = bBallManager.GetComponent<BasketballManager>();
        skeeBallManagerScript = skeeBallManagerScript.GetComponent<SkeeballManagerScript>();
        skeeBallButton.GetComponent<Animator>();
    }
	

    private void OnTriggerEnter(Collider other)
    {

        // Starts the bowling game
        if (other.gameObject.tag == "BowlingButton")
        {
            if( bowlingManagerScript.playingBowling == false)
            {
                bowlingManagerScript.StartBowlingGame();
            }
        }

        // Starts the basketball game
        if (other.gameObject.tag == "BBallButton")
        {
            if (bBallManagerScript.playing == false)
            {
                bBallManagerScript.BasketballGameStart();
            }
        }

        // Starts the skeeball game
        if (other.gameObject.tag == "SkeeballButton")
        {
            if (skeeBallManagerScript.playingSkeeball == false)
            {
                skeeBallManagerScript.PlaySkeeball();
                skeeBallButton.GetComponent<Animation>().Play("buttonDown");

            }
        }
    }

}
