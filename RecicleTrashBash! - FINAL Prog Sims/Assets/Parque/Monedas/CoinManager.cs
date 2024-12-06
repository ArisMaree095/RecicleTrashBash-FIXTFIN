using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TMP_Text coinText; // Asigna el texto de la UI aquí
    private int coinCount = 0; // Contador de monedas
    private int trashCollected = 0; // Contador de basura recogida

    // Método para sumar basura
    public void AddTrash()
    {
        trashCollected++;
        if (trashCollected >= 3)
        {
            AddCoins(3);
            trashCollected = 0; // Reinicia el contador de basura
        }
    }

    // Método para sumar monedas
    private void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateCoinDisplay();
    }

    // Método para actualizar el texto del HUD
    private void UpdateCoinDisplay()
    {
        coinText.text = "Monedas: " + coinCount;
    }
}
