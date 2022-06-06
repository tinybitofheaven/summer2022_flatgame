using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 0.5f;
    public Rigidbody2D playerRb;

    private Vector2 _movement;

    //animator
    public Animator playerAnimator;
    private Vector2 _previousPosition;

    // Start is called before the first frame update
    private void Start()
    {
        _previousPosition = playerRb.position;
    }

    // Update is called once per frame
    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + _movement * playerSpeed);

        //animation
        if (playerRb.position == _previousPosition)
        { //isnt moving
            playerAnimator.SetBool("moving", false);
        }
        else
        {
            playerAnimator.SetBool("moving", true);
        }

        if (_movement.y < 0)
        { //down
            playerAnimator.SetInteger("direction", 0);
        }
        if (_movement.x < 0)
        { //left
            playerAnimator.SetInteger("direction", 1);
        }
        if (_movement.y > 0)
        { //up
            playerAnimator.SetInteger("direction", 2);
        }
        if (_movement.x > 0)
        { //right
            playerAnimator.SetInteger("direction", 3);
        }

        _previousPosition = playerRb.position;

    }
}
