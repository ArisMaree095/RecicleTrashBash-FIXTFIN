using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabsBasura; // 0 = Orgánica, 1 = Metálica, 2 = Vidrio
    public Transform[] puntosSpawn;    // Puntos donde aparecerá la basura
    public int cantidadBasura = 10;

    private int basuraRecogida = 0;

    void Start()
    {
        GenerarBasuraAleatoria();
    }

    void GenerarBasuraAleatoria()
    {
        for (int i = 0; i < cantidadBasura; i++)
        {
            GameObject Spawner = prefabsBasura[Random.Range(0, prefabsBasura.Length)];
            Transform puntoSeleccionado = puntosSpawn[Random.Range(0, puntosSpawn.Length)];
            Instantiate(Spawner, puntoSeleccionado.position, Quaternion.identity);
        }
    }

    public void RecogerBasura()
    {
        basuraRecogida++;
        if (basuraRecogida >= cantidadBasura)
        {
            FindObjectOfType<GameManager>().ActivarIrATienda();
        }
    }
}
