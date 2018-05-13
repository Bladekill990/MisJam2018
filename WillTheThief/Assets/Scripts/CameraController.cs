using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Player player;       //Public variable to store a reference to the player game object
    public RCCar Rckar;       //Public variable to store a reference to the rccar game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (player.control)
        {
            transform.position = player.transform.position + offset;
        } else
        {
            transform.position = Rckar.transform.position + offset;
        }
    }
}
