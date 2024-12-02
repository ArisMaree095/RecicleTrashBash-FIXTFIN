using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float tiempoRestante = 180f; // 3 minutos en segundos
    public TMP_Text timerText; // Referencia al texto UI del temporizador
    public GameObject GameOver; // Pantalla de Game Over

    private bool juegoTerminado = false;

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
        GameOver.SetActive(true); // Mostrar la pantalla de Game Over
        Time.timeScale = 0f; // Pausar el juego
    }

   public void ReiniciarJuego()
    {
        Time.timeScale = 1f; // Restaurar la velocidad del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reiniciar la escena actual
    }
}
