using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1; 
    public GameObject shopUI; 

    void Start()
    {
        if (shopUI != null)
            shopUI.SetActive(false); 
    }

    public void CompleteLevel()
    {
        if (currentLevel < 3)
        {
            shopUI.SetActive(true);
        }
        else
        {
            Debug.Log("¡Has completado todos los niveles!");
        }
        
    }

    public void Button()
    {
        shopUI.SetActive(false); 

        currentLevel++;
        if (currentLevel <= 3)
        {
            LoadLevel(currentLevel); 
        }
    }

    void LoadLevel(int levelNumber)
    {
        string levelName = "Level" + levelNumber;
        SceneManager.LoadScene(levelName);
    }
}

