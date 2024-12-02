using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funda : MonoBehaviour
{
    public enum NivelFunda { Azul, Dorada, Amatista }
    public NivelFunda nivelActual = NivelFunda.Azul;

    public int capacidadMaxima = 3;
    private Queue<GameObject> objetosEnFunda = new Queue<GameObject>();

    public Transform posicionManosJugador; // Posición donde se colocará el objeto a clasificar

    void Start()
    {
        ActualizarCapacidad();
    }

    public void RecogerBasura(GameObject basura)
    {
        if (objetosEnFunda.Count < capacidadMaxima)
        {
            basura.SetActive(false); // Simula que el objeto es recogido
            objetosEnFunda.Enqueue(basura);
            Debug.Log($"Objeto recogido: {basura.name}. Total en funda: {objetosEnFunda.Count}");
        }
        else
        {
            Debug.Log("La funda está llena. Debes clasificar la basura.");
        }
    }

    public void LiberarBasura()
    {
        if (objetosEnFunda.Count > 0)
        {
            GameObject basura = objetosEnFunda.Dequeue();
            basura.SetActive(true); // Reactivar objeto
            basura.transform.position = posicionManosJugador.position; // Colocar en las manos del jugador
            basura.transform.rotation = posicionManosJugador.rotation; // Alinear la rotación
            Debug.Log($"Basura liberada: {basura.name}. Restan {objetosEnFunda.Count} en la funda.");
        }
        else
        {
            Debug.Log("No hay basura para clasificar.");
        }
    }

    public void ActualizarCapacidad()
    {
        switch (nivelActual)
        {
            case NivelFunda.Azul:
                capacidadMaxima = 3;
                break;
            case NivelFunda.Dorada:
                capacidadMaxima = 6;
                break;
            case NivelFunda.Amatista:
                capacidadMaxima = 10;
                break;
        }
        Debug.Log($"Capacidad de la funda actualizada a {capacidadMaxima}.");
    }

    // Este método puede llamarse al mejorar la pinza desde la tienda o al cargar el nivel
    public void MejorarFunda(string nuevoNivel)
    {
        switch (nuevoNivel)
        {
            case "Azul":
                nivelActual = NivelFunda.Azul;
                break;
            case "Dorada":
                nivelActual = NivelFunda.Dorada;
                break;
            case "Amatista":
                nivelActual = NivelFunda.Amatista;
                break;
        }
        ActualizarCapacidad();
    }
}
