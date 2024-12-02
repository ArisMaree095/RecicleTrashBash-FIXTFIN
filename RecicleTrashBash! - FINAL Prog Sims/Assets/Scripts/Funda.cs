using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funda : MonoBehaviour
{
    public enum NivelFunda { Azul, Dorada, Amatista }
    public NivelFunda nivelActual;
    public int capacidadMaxima;

    void Start()
    {
        // Cargar el nivel de la funda desde PlayerPrefs al iniciar la escena del juego
        string nivelFundaGuardado = PlayerPrefs.GetString("NivelFunda", "Azul");
        MejorarFunda(nivelFundaGuardado);
    }

    public void MejorarFunda(string nuevoNivel)
    {
        switch (nuevoNivel)
        {
            case "Azul":
                nivelActual = NivelFunda.Azul;
                capacidadMaxima = 3;
                break;
            case "Dorada":
                nivelActual = NivelFunda.Dorada;
                capacidadMaxima = 6;
                break;
            case "Amatista":
                nivelActual = NivelFunda.Amatista;
                capacidadMaxima = 10;
                break;
        }
        Debug.Log($"Funda mejorada a {nivelActual} con capacidad {capacidadMaxima}");
    }
}
