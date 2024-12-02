using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clasifica : MonoBehaviour
{
    public string BasuraTipo;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(BasuraTipo))
        {
            Debug.Log($"Objeto {other.gameObject.name} clasificado correctamente como {BasuraTipo}");
        }
        else
        {
            Debug.Log($"Objeto {other.gameObject.name} no pertenece al contenedor {BasuraTipo}");
        }
    }
}
