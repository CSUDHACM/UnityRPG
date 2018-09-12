using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    private Animator anim;
    private float horizontalDir, verticalDir, lastX, lastY;
    private bool isMoving;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update () {
        horizontalDir = Input.GetAxisRaw("Horizontal");
        verticalDir = Input.GetAxisRaw("Vertical");
        isMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(horizontalDir * moveSpeed * Time.deltaTime, 0f, 0f));
            isMoving = true;
            lastX = horizontalDir;
            lastY = 0f;
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, verticalDir * moveSpeed * Time.deltaTime, 0f));
            isMoving = true;
            lastX = 0f;
            lastY = verticalDir;
        }

        anim.SetFloat("MoveX", horizontalDir);
        anim.SetFloat("MoveY", verticalDir);
        anim.SetBool("IsMoving", isMoving);
        anim.SetFloat("LastMoveX", lastX);
        anim.SetFloat("LastMoveY", lastY);
    }
}
