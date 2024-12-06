using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMetal : MonoBehaviour
{
    public string Metal;

    public void changeScene()
    {
        SceneManager.LoadScene(Metal);
    }
}
