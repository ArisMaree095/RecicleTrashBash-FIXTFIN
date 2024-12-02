using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabsBasura; // 0 = Orgánica, 1 = Metálica, 2 = Vidrio
    public Transform[] puntosSpawn;    // Puntos donde aparecerá la basura
    public int cantidadBasura = 10;

    void Start()
    {
        GenerarBasuraAleatoria();
    }

    void GenerarBasuraAleatoria()
    {
        for (int i = 0; i < cantidadBasura; i++)
        {
            // Seleccionar un prefab y punto de spawn aleatorio
          /*  GameObject Organic = prefabsBasura[Random.Range(0, prefabsBasura.Length)];
            GameObject Metal = prefabsBasura[Random.Range(0, prefabsBasura.Length)];
            GameObject Glass = prefabsBasura[Random.Range(0, prefabsBasura.Length)];*/
            GameObject Spawner = prefabsBasura[Random.Range(0, prefabsBasura.Length)];

            Transform puntoSeleccionado = puntosSpawn[Random.Range(0, puntosSpawn.Length)];

            // Instanciar la basura en el punto aleatorio
            Instantiate(Spawner, puntoSeleccionado.position, Quaternion.identity);
        }
    }
}
