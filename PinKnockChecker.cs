using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script checks whether the pins have collided with
// the ground collider and communicates this with the BowlingGameScript
public class PinKnockChecker : MonoBehaviour
{
    // Checks which pins have collided with the ground
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pin1")
        {
            BowlingGameScript.instance.pinsDown++;
            BowlingGameScript.instance.Pin1Down = true;
        }
        if (other.gameObject.tag == "Pin2")
        {
            BowlingGameScript.instance.pinsDown++;
            BowlingGameScript.instance.Pin2Down = true;
        }
        if (other.gameObject.tag == "Pin3")
        {
            BowlingGameScript.instance.pinsDown++;
            BowlingGameScript.instance.Pin3Down = true;
        }
        if (other.gameObject.tag == "Pin4")
        {
            BowlingGameScript.instance.pinsDown++;
            BowlingGameScript.instance.Pin4Down = true;
        }
        if (other.gameObject.tag == "Pin5")
        {
            BowlingGameScript.instance.pinsDown++;
            BowlingGameScript.instance.Pin5Down = true;
        }
        if (other.gameObject.tag == "Pin6")
        {
            BowlingGameScript.instance.pinsDown++;
            BowlingGameScript.instance.Pin6Down = true;
        }
        if (other.gameObject.tag == "Pin7")
        {
            BowlingGameScript.instance.pinsDown++;
            BowlingGameScript.instance.Pin7Down = true;
        }
        if (other.gameObject.tag == "Pin8")
        {
            BowlingGameScript.instance.pinsDown++;
            BowlingGameScript.instance.Pin8Down = true;
        }
        if (other.gameObject.tag == "Pin9")
        {
            BowlingGameScript.instance.pinsDown++;
            BowlingGameScript.instance.Pin9Down = true;
        }
        if (other.gameObject.tag == "Pin10")
        {
            BowlingGameScript.instance.pinsDown++;
            BowlingGameScript.instance.Pin10Down = true;
        }
    }



}
