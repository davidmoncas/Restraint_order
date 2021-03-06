﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharacter : MonoBehaviour
{

    public float speed = 0.5f;
    private Rigidbody2D rb;
    Vector2 movement;
    SpriteRenderer sr;
    public AudioSource steps;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        this.GetComponent<Animator>().SetFloat("horizontal", 0);
        this.GetComponent<Animator>().SetFloat("vertical", 0);
    }

    void Update()
    {

        if (!gameState.playing) {
            this.GetComponent<Animator>().SetBool("moving", false);
            return; 
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.magnitude > 0)
        {
            this.GetComponent<Animator>().SetFloat("horizontal", movement.x);
            this.GetComponent<Animator>().SetFloat("vertical", movement.y);
            if (!steps.isPlaying) steps.Play();
        }

        this.GetComponent<Animator>().SetBool("moving", movement.magnitude > 0);

 
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        sr.sortingOrder = 100-(int)((transform.position.y + 5) * 10);
        
    }

}
