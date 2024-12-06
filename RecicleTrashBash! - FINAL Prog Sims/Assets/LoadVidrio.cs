using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadVidrio : MonoBehaviour
{
    public string Vidrio;

    public void changeScene2()
    {
        SceneManager.LoadScene(Vidrio);
    }

}
