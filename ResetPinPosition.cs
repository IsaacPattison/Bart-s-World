using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the bowling pins
public class ResetPinPosition : MonoBehaviour {

    public Vector3 position;

    public Quaternion rotation;

    public AudioSource pinSFX;

    // Find the Audio Component in the Pin
    private void Start()
    {
        pinSFX = GetComponent<AudioSource>();
    }

    // Sets the Pin location on play
    void Awake()
    {
        position = gameObject.transform.position;
        rotation = gameObject.transform.rotation;
    }

    void Update()
    {
        // Use this for Debug Purposes
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ResetPin();
        }
        
    }

    // Resets the location and velocity of the pin
    public void ResetPin()
    {
        gameObject.transform.position = position;
        gameObject.transform.rotation = rotation;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    // Trigger Pin hit Sound Effect
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BowlingBall" || collision.gameObject.tag == "Ground")
        {
            pinSFX.Play ();
        }
    }


}
