using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharacter : MonoBehaviour
{

    public float speed = 0.5f;
    public Transform dog;
    public Transform girl;
    public Transform boyfriend;
    public Healthbar detection;

    public float minDistance = 2;

    public SpriteRenderer dogGradient, girlGradient, boyfriendGradient;

    public float distanceToGirl, distanceToDog, distanceToBoyfriend;

    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        distanceToGirl = Vector2.Distance(transform.position, girl.position);
        distanceToDog = Vector2.Distance(transform.position, dog.position);
        distanceToBoyfriend = Vector2.Distance(transform.position, boyfriend.position);

        if (distanceToBoyfriend < minDistance) {
            boyfriendGradient.color = new Color(boyfriendGradient.color.r, boyfriendGradient.color.g, boyfriendGradient.color.b, (minDistance - distanceToBoyfriend)/ minDistance);
            detection.healthPerSecond = 40-distanceToBoyfriend/minDistance*40;
        }

        if (distanceToGirl < minDistance*2)
        {
            girlGradient.color = new Color(girlGradient.color.r, girlGradient.color.g, girlGradient.color.b, (minDistance*2- distanceToGirl+1) / (minDistance*2));
            detection.healthPerSecond = 40 - distanceToGirl / minDistance * 20;
            print(distanceToGirl);
        }

        if (distanceToDog < minDistance)
        {
            dogGradient.color = new Color(dogGradient.color.r, dogGradient.color.g, dogGradient.color.b, (minDistance - distanceToDog) / minDistance);
            detection.healthPerSecond = 40 - distanceToDog / minDistance * 40;
        }



        if (distanceToBoyfriend> minDistance && distanceToGirl > minDistance*2 && distanceToDog> minDistance) detection.healthPerSecond = -10;


        movement();
        
    }


    void movement() {
        //rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0) * Time.deltaTime);
        rb.velocity = (new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed));
    }


}
