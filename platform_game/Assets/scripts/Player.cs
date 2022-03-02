using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5.0f;
    [SerializeField] float jumpSpeed = 5.0f;
    [SerializeField] float climbSpeed = 5.0f;
    [SerializeField] Vector2 deathSeq = new Vector2(25f,25f);
    [SerializeField] AudioClip jump;
    AudioSource sfx;


    bool Alive = true;

    Rigidbody2D playerCharacter;
    Animator playerAnimator;
    BoxCollider2D playerBodyCollider;
    CapsuleCollider2D playerFeetCollider;

    float gravityScaleAtStart;

    // Start is called before the first frame update
    void Start(){
        playerCharacter = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerBodyCollider = GetComponent<BoxCollider2D>();
        playerFeetCollider = GetComponent<CapsuleCollider2D>();
        sfx = GetComponent<AudioSource>();

        gravityScaleAtStart = playerCharacter.gravityScale;
    }

    // Update is called once per frame
    void Update(){
        
        if (!Alive){
            return;
        }
        
        Run();
        FlipSprite();
        Jump();
        Climb();
        DogDied();
    }

    private void DogDied(){
        /*bool die1 = false;
        bool die2 = false;
        bool die3 = false;*/
        if(playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazards","BadPickup")))
        {
            /*if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy"))){
            }
            else if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Hazards"))){
            }
            else if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("BadPickup"))){
            }*/
            Alive = false;
            playerAnimator.SetTrigger("Die");
            GetComponent<Rigidbody2D>().velocity = deathSeq;
            FindObjectOfType<gameSession>().processPlayerDeath();
        }



    }

    private void Run(){
        // Value between -1 to +1
        float hMovement = Input.GetAxis("Horizontal");
        Vector2 runVelocity = new Vector2(hMovement * runSpeed, playerCharacter.velocity.y);
        playerCharacter.velocity = runVelocity;

        playerAnimator.SetBool("Run", true);

        bool hSpeed = Mathf.Abs(playerCharacter.velocity.x) > Mathf.Epsilon;

        playerAnimator.SetBool("Run", hSpeed);

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

        if(!playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            return;
        }
        
        if(Input.GetButtonDown("Jump")){
            //get new y velocity bsed on controllable variable
            
            Vector2 jumpVelocity = new Vector2(0.0f, jumpSpeed);
            playerCharacter.velocity += jumpVelocity;
            //here
            bool vSpeed = Mathf.Abs(playerCharacter.velocity.y) > Mathf.Epsilon;
            playerAnimator.SetBool("Jump", vSpeed);
            sfx.PlayOneShot(jump, 1.0f);
        }

        //yep

    }

    private void Climb(){
        if(!playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))){
            playerAnimator.SetBool("Climb", false);
            playerCharacter.gravityScale = gravityScaleAtStart;
            return;
        }
        float vMovement = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(playerCharacter.velocity.x, vMovement * climbSpeed);
        playerCharacter.velocity = climbVelocity;

        playerCharacter.gravityScale = 0.0f;

        bool vSpeed = Mathf.Abs(playerCharacter.velocity.y) > Mathf.Epsilon;
        playerAnimator.SetBool("Climb", vSpeed);
    }

}
