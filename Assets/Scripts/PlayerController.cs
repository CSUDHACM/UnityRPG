using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;     //Movement speed for the player.
    private Animator anim;      //Variable anim declared as Animator object.
    private float horizontalDir, verticalDir, lastX, lastY;     //horizontalDir & verticalDir determine the direction of the player inputs.
                                                               //lastX & lastY stores the last input in the appropriate axis for later use.
    private bool isMoving;      //Boolean isMoving determines whether the player is currently moving.

    void Start()
    {
        anim = GetComponent<Animator>();    //Gets Player's Animator component and stores it as an anim variable.
                                           //This allows for access to Animator's functions, used to determine walking animations.
    }

    void Update () {
        horizontalDir = Input.GetAxisRaw("Horizontal"); //Gets horizontal input from the player (A, D, LeftArrow, RightArrow).
        verticalDir = Input.GetAxisRaw("Vertical");     //Gets vertical input from the player (W, S, UpArrow, DownArrow).
        isMoving = false;                               //Sets isMoving to false automatically.

        if (horizontalDir > 0.5f || horizontalDir < -0.5f)  //Checks whether the player has inputted 1 or -1. GetAxisRaw() returns -1 / 1.
        {
            transform.Translate(new Vector3(horizontalDir * moveSpeed * Time.deltaTime, 0f, 0f));   //Moves player using a vector3 object.
            //Vector3 takes in x, y, and z directions, so we manipulate the axis through the corresponding input. 
            isMoving = true;        //Sets isMoving to true.
            lastX = horizontalDir;  //Stores the last direction into lastX for the anim object.
            lastY = 0f;             //Resets lastY to 0 for the anim object.
        }
        if (verticalDir > 0.5f || verticalDir < -0.5f)  //Similar to the first if statement, only for the vertical axis.
        {
            transform.Translate(new Vector3(0f, verticalDir * moveSpeed * Time.deltaTime, 0f));
            isMoving = true;
            lastX = 0f;
            lastY = verticalDir;
        }

        anim.SetFloat("MoveX", horizontalDir);  //Sets float MoveX in anim object to horizontalDir.  (Current frame input)
        anim.SetFloat("MoveY", verticalDir);    //Sets float MoveY in anim object to verticalDir.    (Current frame input)
        anim.SetBool("IsMoving", isMoving);     //Sets bool isMoving in anim object to isMoving.
        anim.SetFloat("LastMoveX", lastX);      //Sets float LastMoveX to lastX.                     (Last input)
        anim.SetFloat("LastMoveY", lastY);      //sets float LastMoveY to lastY.                     (Last input)
    }
}
