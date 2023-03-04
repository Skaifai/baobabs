using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 40f;

    [SerializeField]
    private Rigidbody2D playerRigidBody;

    [SerializeField]
    private Transform playerTransform;

    private float xMove = 0;
    private float yMove = 0;
    private Vector2 destination;
    private Vector2 interpolated;

    private float horizontalMovement = 0f;
    private float verticalMovement = 0f;

    [SerializeField]
    private Animator playerAnimator;

    private void Awake()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerTransform = gameObject.transform;
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * runSpeed;
        if (horizontalMovement > 0f)
        {
            playerAnimator.SetBool("IsWalkingRight", true);
        }
        else if (horizontalMovement < 0f)
        {
            playerAnimator.SetBool("IsWalkingLeft", true);
        }
        else 
        {
            playerAnimator.SetBool("IsWalkingRight", false);
            playerAnimator.SetBool("IsWalkingLeft", false);
        }

        verticalMovement = Input.GetAxis("Vertical") * runSpeed;
        if (verticalMovement > 0f)
        {
            playerAnimator.SetBool("IsWalkingUp", true);
        }
        else if (verticalMovement < 0f)
        {
            playerAnimator.SetBool("IsWalkingDown", true);
        }
        else
        {
            playerAnimator.SetBool("IsWalkingUp", false);
            playerAnimator.SetBool("IsWalkingDown", false);
        }


        xMove = horizontalMovement * Time.deltaTime;
        yMove = verticalMovement * Time.deltaTime;

        destination = new Vector2(playerTransform.localPosition.x + xMove, 
            playerTransform.localPosition.y + yMove);

        interpolated = Vector2.Lerp(playerTransform.localPosition, destination, 0.5f);

        Debug.Log(interpolated);

        playerRigidBody.MovePosition(interpolated);
    }
}
