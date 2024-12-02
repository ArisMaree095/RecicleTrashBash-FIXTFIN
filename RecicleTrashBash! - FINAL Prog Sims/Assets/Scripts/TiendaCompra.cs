using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaCompra : MonoBehaviour
{
    public Text monedasText; // UI para mostrar las monedas del jugador
    public Funda funda;       // Referencia a la funda para aplicar las mejoras
    private int monedas;

    void Start()
    {
        // Cargar las monedas y el nivel de la funda desde PlayerPrefs
        monedas = PlayerPrefs.GetInt("Monedas", 0);
        string nivelFundaGuardado = PlayerPrefs.GetString("NivelFunda", "Azul");
        funda.MejorarFunda(nivelFundaGuardado);
        ActualizarUI();
    }

    public void ComprarMejora(string nivelFunda)
    {
        int costo = ObtenerCosto(nivelFunda);

        // Verificar que el jugador tenga suficientes monedas y que no intente comprar un nivel inferior
        if (monedas >= costo && EsNivelSuperior(nivelFunda))
        {
            monedas -= costo;
            PlayerPrefs.SetString("NivelFunda", nivelFunda);
            PlayerPrefs.SetInt("Monedas", monedas);
            PlayerPrefs.Save();

            // Aplicar la mejora al instante
            funda.MejorarFunda(nivelFunda);
            ActualizarUI();
            Debug.Log($"Has comprado la funda {nivelFunda}. Monedas restantes: {monedas}");
        }
        else
        {
            Debug.Log("No tienes suficientes monedas o ya tienes un nivel superior.");
        }
    }

    private int ObtenerCosto(string nivelFunda)
    {
        switch (nivelFunda)
        {
            case "Azul": return 10;
            case "Dorada": return 20;
            case "Amatista": return 30;
            default: return 0;
        }
    }

    private bool EsNivelSuperior(string nivelFunda)
    {
        string nivelActual = PlayerPrefs.GetString("NivelFunda", "Azul");
        return ObtenerPrioridad(nivelFunda) > ObtenerPrioridad(nivelActual);
    }

    private int ObtenerPrioridad(string nivelFunda)
    {
        switch (nivelFunda)
        {
            case "Azul": return 1;
            case "Dorada": return 2;
            case "Amatista": return 3;
            default: return 0;
        }
    }

    private void ActualizarUI()
    {
        monedasText.text = $"Monedas: {monedas}";
    }
}