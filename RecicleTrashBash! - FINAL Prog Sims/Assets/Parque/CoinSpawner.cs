using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab de la moneda
    public int maxCoins = 5; // Número de monedas a spawnear
    public Transform[] spawnPoints; // Puntos donde se pueden spawnear las monedas

    void Start()
    {
        // Verificar si hay puntos de spawn asignados
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No hay puntos de spawn asignados. Por favor, asigna puntos de spawn en el Inspector.");
            return;
        }

        for (int i = 0; i < maxCoins; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(coinPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        }
    }
}
