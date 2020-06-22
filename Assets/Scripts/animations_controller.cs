using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations_controller : MonoBehaviour
{

    public Animator duck, boyfriend;
    public GameObject migas , inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            duck.SetTrigger("chase");
            boyfriend.SetTrigger("run");
            migas.SetActive(true);
        };
    }


    public void useBread() {
        duck.SetTrigger("chase");
        boyfriend.SetTrigger("run");
        migas.SetActive(true);
        inventory.SetActive(false);

    }
}
