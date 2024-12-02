using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Funda : MonoBehaviour
{
    public enum NivelFunda { Ninguna, Azul, Dorada, Amatista }
    public NivelFunda nivelActual = NivelFunda.Ninguna;

    public int capacidadActual = 0;
    private Queue<GameObject> inventario = new Queue<GameObject>();

    public Transform posicionManosJugador;
    public UnityEvent onInventarioLleno; // Evento cuando el inventario está lleno
    public UnityEvent onBasuraRecogida; // Evento cuando se recoge basura

    void Start()
    {
        string nivelFundaGuardado = PlayerPrefs.GetString("NivelFunda", "Ninguna");
        MejorarFunda(nivelFundaGuardado);
    }

    public bool RecogerBasura(GameObject basura)
    {
        if (nivelActual == NivelFunda.Ninguna)
        {
            Debug.Log("No tienes una funda disponible.");
            return false; // Si no tienes una funda, retornamos false
        }

        if (inventario.Count >= capacidadActual)
        {
            Debug.Log("La funda está llena.");
            onInventarioLleno?.Invoke(); // Invoca el evento
            return false; // Si el inventario está lleno, retornamos false
        }

        inventario.Enqueue(basura); // Se agrega la basura al inventario
        onBasuraRecogida?.Invoke(); 
        return true; // Si todo va bien, retornamos true
    }
    public void LiberarBasura()
    {
        if (inventario.Count > 0)
        {
            GameObject basura = inventario.Dequeue();
            basura.SetActive(true);
            basura.transform.position = posicionManosJugador.position;
            Debug.Log($"Basura liberada: {basura.name}. Quedan {inventario.Count} en la funda.");
        }
        else
        {
            Debug.Log("No hay basura para liberar.");
        }
    }

    public void MejorarFunda(string nuevoNivel)
    {
        switch (nuevoNivel)
        {
            case "Azul":
                nivelActual = NivelFunda.Azul;
                capacidadActual = 3;
                break;
            case "Dorada":
                nivelActual = NivelFunda.Dorada;
                capacidadActual = 6;
                break;
            case "Amatista":
                nivelActual = NivelFunda.Amatista;
                capacidadActual = 10;
                break;
            default:
                nivelActual = NivelFunda.Ninguna;
                capacidadActual = 0;
                break;
        }
     Debug.Log($"Funda mejorada a {nivelActual} con capacidad {capacidadActual}.");  
    }
       
    public int ObtenerCantidadBasura()
    {
        return inventario.Count;
    }
   
}


