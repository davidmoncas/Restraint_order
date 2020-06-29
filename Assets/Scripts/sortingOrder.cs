using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortingOrder : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.sortingOrder = 100-(int)((transform.position.y + 5) * 10);
    }
}
