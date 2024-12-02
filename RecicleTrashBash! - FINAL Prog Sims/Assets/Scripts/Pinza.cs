using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinza : MonoBehaviour
{
    public enum PinzaNivel { Roja, Azul, Dorada, Amatista }
    public PinzaNivel nivelActual = PinzaNivel.Roja;

    public int capacidadActual = 1;
    public List<GameObject> inventario = new List<GameObject>();
    private Renderer pinzaRenderer;

    // Materiales para los distintos niveles
    public Material materialRojo;
    public Material materialAzul;
    public Material materialDorado;
    public Material materialAmatista;

    public Funda funda;  // Referencia a la funda

    public void RecogerObjeto(GameObject basura)
    {
        if (funda != null)
        {
            funda.RecogerBasura(basura);
        }
        else
        {
            Debug.Log("No tienes la funda.");
        }
    }
    void Start()
    {
        // Cargar el nivel guardado desde PlayerPrefs
        int nivelGuardado = PlayerPrefs.GetInt("NivelPinza", 0);
        nivelActual = (PinzaNivel)nivelGuardado;
        ActualizarCapacidad();
        ActualizarMaterial();
    }

    private void ActualizarCapacidad()
    {
        switch (nivelActual)
        {
            case PinzaNivel.Roja:
                capacidadActual = 1;
                break;
            case PinzaNivel.Azul:
                capacidadActual = 3;
                break;
            case PinzaNivel.Dorada:
                capacidadActual = 6;
                break;
            case PinzaNivel.Amatista:
                capacidadActual = 10;
                break;
        }
    }

    public void RecogerBasura(GameObject basura)
    {
        if (inventario.Count < capacidadActual)
        {
            inventario.Add(basura);
            basura.SetActive(false);  // Simula que es recogida
            Debug.Log($"Basura recogida: {basura.name}. Total en inventario: {inventario.Count}");
        }
        else
        {
            Debug.Log("Inventario lleno. Debes clasificar la basura.");
        }
    }

    public void ClasificarBasura()
    {
        if (inventario.Count > 0)
        {
            GameObject basura = inventario[0];
            inventario.RemoveAt(0);
            basura.SetActive(true);  // Simula que es liberada para clasificar
            basura.transform.position = transform.position + Vector3.forward * 2;  // Coloca el objeto frente a la pinza
            Debug.Log($"Basura clasificada: {basura.name}. Quedan {inventario.Count} en el inventario.");
        }
        else
        {
            Debug.Log("No hay basura para clasificar.");
        }
    }

    private void ActualizarMaterial()
    {
        pinzaRenderer = GetComponent<Renderer>();
        switch (nivelActual)
        {
            case PinzaNivel.Roja:
                pinzaRenderer.material = materialRojo;
                break;
            case PinzaNivel.Azul:
                pinzaRenderer.material = materialAzul;
                break;
            case PinzaNivel.Dorada:
                pinzaRenderer.material = materialDorado;
                break;
            case PinzaNivel.Amatista:
                pinzaRenderer.material = materialAmatista;
                break;
        }
    }
}
    


