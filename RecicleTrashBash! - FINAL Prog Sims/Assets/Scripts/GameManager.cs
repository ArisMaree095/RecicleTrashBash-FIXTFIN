using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float tiempoRestante = 180f; 
    public TMP_Text timerText; 
    public GameObject GameOver; 
    public Image fadeImage;  
    public float fadeDuration = 2f;  

    private bool juegoTerminado = false;

    // Update se llama una vez por frame
    void Update()
    {
        if (!juegoTerminado)
        {
            tiempoRestante -= Time.deltaTime; 
            ActualizarTimerUI(); 

            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0; 
                TerminarJuego(); 
            }
        }
    }

    void ActualizarTimerUI()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60); 
        int segundos = Mathf.FloorToInt(tiempoRestante % 60); 
        timerText.text = string.Format("{0:00}:{1:00}", minutos, segundos); 
    }

    void TerminarJuego()
    {
        juegoTerminado = true;
        StartCoroutine(FadeOut()); 
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration); // Interpolación para el alpha
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            elapsedTime += Time.deltaTime; // Aumenta el tiempo de transición
            yield return null; // Espera el siguiente frame
        }

        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);

        GameOver.SetActive(true); 
        Time.timeScale = 0f; 
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena actual
    }
}
