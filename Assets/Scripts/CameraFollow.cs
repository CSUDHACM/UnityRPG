using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Vector3 offset;  //Variable offset declared as a Vector3 Object, stores X, Y, and Z coordinates.
    public Transform lookAt;    //Variable lookAt declared as Transform object, 
                                    //behaves as coordinates to move the camera to the player's position.

    private static bool cameraExists;   //Variable to determine whether the camera already exists in a scene, if so do not create a new
                                            //camera whenever entering another scene.

    private void Start()
    {
        if (!cameraExists)
        {
            cameraExists = true;    //Sets player exists to true to prevent duplicating player.
            DontDestroyOnLoad(transform.gameObject);    //Prevents destroying the current player object whenever moving to another scene.
        }
        else
        {
            Destroy(transform.gameObject);  //Destroy player when unity duplicates player upon moving to an ew scene
        }
    }

    void LateUpdate() {
        transform.position = lookAt.position + offset;
	}
}
