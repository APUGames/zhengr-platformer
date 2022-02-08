using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5.0f;
    [SerializeField] float jumpSpeed = 5.0f;


    Rigidbody2D playerCharacter;
    Animator playerAnimator;
    Collider2D playerCollider;    

    // Start is called before the first frame update
    void Start(){
        playerCharacter = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update(){
        Run();
        FlipSprite();
        Jump();
    }

    private void Run(){
        // Value between -1 to +1
        float hMovement = Input.GetAxis("Horizontal");
        Vector2 runVelocity = new Vector2(hMovement * runSpeed, playerCharacter.velocity.y);
        playerCharacter.velocity = runVelocity;

        playerAnimator.SetBool("run", true);

        bool hSpeed = Mathf.Abs(playerCharacter.velocity.x) > Mathf.Epsilon;

        playerAnimator.SetBool("run", hSpeed);

        print(runVelocity);

    }

    private void FlipSprite()
    {
        // If the player is moving horizontally
        bool hMovement = Mathf.Abs(playerCharacter.velocity.x) > Mathf.Epsilon;

        if(hMovement)
        {
            // Reverse the current scaling of the X-axis
            transform.localScale = new Vector2(Mathf.Sign(playerCharacter.velocity.x), 1f);
        }
    }

    private void Jump(){
        if(!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            return;
        }
        if(Input.GetButtonDown("Jump")){
            //get new y velocity bsed on controllable variable
            Vector2 jumpVelocity = new Vector2(0.0f, jumpSpeed);
            playerCharacter.velocity += jumpVelocity;
        }
    }

}
