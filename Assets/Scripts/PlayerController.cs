using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;     //Movement speed for the player.
    private Animator anim;      //Variable anim declared as Animator object.
    private float horizontalDir, verticalDir, lastX, lastY;     //horizontalDir & verticalDir determine the direction of the player inputs.
                                                               //lastX & lastY stores the last input in the appropriate axis for later use.
    private bool isMoving;      //Boolean isMoving determines whether the player is currently moving.
    private Rigidbody2D playerRB;   //Variable playerRB declared as RigidBody2D

    private static bool playerExists;   //Variable to determine whether the player already exists in a scene, if so do not create a new
                                            //player whenever entering another scene.

    void Start()
    {
        anim = GetComponent<Animator>();    //Gets Player's Animator component and stores it as an anim variable.
                                            //This allows for access to Animator's functions, used to determine walking animations.
        playerRB = GetComponent<Rigidbody2D>(); //Gets Player's RigidBody2D component.

        if(!playerExists)
        {
            playerExists = true;    //Sets player exists to true to prevent duplicating player.
            DontDestroyOnLoad(transform.gameObject);    //Prevents destroying the current player object whenever moving to another scene.
        }
        else
        {
            Destroy(transform.gameObject);  //Destroy player when unity duplicates player upon moving to an ew scene
        }

    }

    void Update () {
        horizontalDir = Input.GetAxisRaw("Horizontal"); //Gets horizontal input from the player (A, D, LeftArrow, RightArrow).
        verticalDir = Input.GetAxisRaw("Vertical");     //Gets vertical input from the player (W, S, UpArrow, DownArrow).
        isMoving = false;                               //Sets isMoving to false automatically.

        //These two if statements check whether the player has inputted movement, if so it adds a force to the RigidBody2D to move the Player.
        if (horizontalDir > 0.5f || horizontalDir < -0.5f)  
        {
            //transform.Translate(new Vector3(horizontalDir * moveSpeed * Time.deltaTime, 0f, 0f));   //Moves player using a vector3 object.
            //Vector3 takes in x, y, and z directions, so we manipulate the axis through the corresponding input. 

            playerRB.velocity = new Vector2(horizontalDir * moveSpeed, playerRB.velocity.y);    //Moves the player through manipulating the RigidBody.
            isMoving = true;        //Sets isMoving to true.
            lastX = horizontalDir;  //Stores the last direction into lastX for the anim object.
            lastY = 0f;             //Resets lastY to 0 for the anim object.
        }
        if (verticalDir > 0.5f || verticalDir < -0.5f)  //Similar to the first if statement, only for the vertical axis.
        {
            //transform.Translate(new Vector3(0f, verticalDir * moveSpeed * Time.deltaTime, 0f));

            playerRB.velocity = new Vector2(playerRB.velocity.x, verticalDir * moveSpeed);
            isMoving = true;
            lastX = 0f;
            lastY = verticalDir;
        }

        //These if statements check whether there is no longer force input, if there is none then set RB axis force to 0.
        if (horizontalDir == 0)
        {
            playerRB.velocity = new Vector2(0f, playerRB.velocity.y);
        }
        if (verticalDir == 0)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0f);
        }

        anim.SetFloat("MoveX", horizontalDir);  //Sets float MoveX in anim object to horizontalDir.  (Current frame input)
        anim.SetFloat("MoveY", verticalDir);    //Sets float MoveY in anim object to verticalDir.    (Current frame input)
        anim.SetBool("IsMoving", isMoving);     //Sets bool isMoving in anim object to isMoving.
        anim.SetFloat("LastMoveX", lastX);      //Sets float LastMoveX to lastX.                     (Last input)
        anim.SetFloat("LastMoveY", lastY);      //sets float LastMoveY to lastY.                     (Last input)
    }
}
