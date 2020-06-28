using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharacter : MonoBehaviour
{

    public float speed = 0.5f;
    private Rigidbody2D rb;
    Vector2 movement;
    int direction;
    float velocity;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.magnitude > 0)
        {
            this.GetComponent<Animator>().SetFloat("horizontal", movement.x);
            this.GetComponent<Animator>().SetFloat("vertical", movement.y);
        }

        this.GetComponent<Animator>().SetBool("moving", movement.magnitude > 0);

 


        Debug.Log(rb.velocity.magnitude);
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        
        
    }

}
