using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasificadorBasura : MonoBehaviour
{
    public enum TipoBasura { Organica, Metalica, Vidrio }
    public TipoBasura tipoClasificador; // Asignar el tipo correcto a cada contenedor
    private int contadorClasificacion = 0;
    private int monedas = 0;

    void OnTriggerEnter(Collider other)
    {
        Basura basura = other.GetComponent<Basura>();
        if (basura != null && basura.tipo == tipoClasificador)
        {
            Debug.Log($"Basura {basura.tipo} desechada.");
            Destroy(other.gameObject); // Destruir la basura clasificada
            contadorClasificacion++;

            if (contadorClasificacion % 3 == 0)
            {
                monedas += 4;
                Debug.Log($"Monedas actuales: {monedas}");
            }
        }
        else
        {
            Debug.Log("No hay basura.");
        }
    }
}
