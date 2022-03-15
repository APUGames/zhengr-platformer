using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goodScript : MonoBehaviour
{

Rigidbody2D enemyCharacter;

[SerializeField] float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyCharacter = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight()) {
            enemyCharacter.velocity = new Vector2(moveSpeed, 0);
        }
        else {
            enemyCharacter.velocity = new Vector2(-moveSpeed, 0);
        }

    }

    bool IsFacingRight() {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(enemyCharacter.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            FindObjectOfType<exitScript>().winCon = true;
        }
        else {
            transform.localScale = new Vector2(-(Mathf.Sign(enemyCharacter.velocity.x)), 1.0f);
        }
    }
}
