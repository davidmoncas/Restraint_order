using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToScene : MonoBehaviour
{

    public int scene;

    public void openScene()
    {
        SceneManager.LoadScene(scene);
    }


}
