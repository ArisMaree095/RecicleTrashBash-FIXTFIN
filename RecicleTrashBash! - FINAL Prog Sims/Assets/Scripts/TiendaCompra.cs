using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TiendaCompra : MonoBehaviour
{
    public TMP_Text DineroText;

    private int monedas;
    private string nivelFunda;

    public Material MaterialRojo;
    public Material MaterialAzul;
    public Material MaterialDorado;
    public Material MaterialAmatista;

    void Start()
    {
        monedas = PlayerPrefs.GetInt("Monedas", 0);
        nivelFunda = PlayerPrefs.GetString("NivelFunda", "Rojo");
        ActualizarUI();
    }

    public void ComprarMejora(string nuevoNivel)
    {
        int costo = ObtenerCosto(nuevoNivel);

        if (monedas >= costo)
        {
            monedas -= costo;
            PlayerPrefs.SetInt("Monedas", monedas);
            PlayerPrefs.SetString("NivelFunda", nuevoNivel);
            PlayerPrefs.Save();
            ActualizarUI();

            Debug.Log($"Compraste la mejora: {nuevoNivel}. Monedas restantes: {monedas}");
        }
        else
        {
            Debug.Log("No tienes suficientes monedas.");
        }
    }

    private int ObtenerCosto(string tipoMejora)
    {
        switch (tipoMejora)
        {
            case "Azul": return 10;
            case "Dorado": return 20;
            case "Amatista": return 30;
            default: return 0;
        }
    }

    private void ActualizarUI()
    {
        DineroText.text = $"Monedas: {monedas}";
    }

    public void RegresarAlJuego()
    {
        SceneManager.LoadScene(3);
    }
}
