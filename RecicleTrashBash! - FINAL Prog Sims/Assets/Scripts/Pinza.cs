using UnityEngine;

public class Pinza : MonoBehaviour
{
    public Material MaterialRojo;
    public Material MaterialAzul;
    public Material MaterialDorado;
    public Material MaterialAmatista;

    private Renderer pinzaRenderer;

    void Start()
    {
        pinzaRenderer = GetComponent<Renderer>();

        // Cargar el nivel de mejora solo si ha cambiado desde el nivel base "Rojo"
        string nivelFunda = PlayerPrefs.GetString("NivelFunda", "Rojo");

        if (nivelFunda != "Rojo")
        {
            CambiarMaterial(nivelFunda);
        }
    }

    public void CambiarMaterial(string nivel)
    {
        switch (nivel)
        {
            case "Azul":
                pinzaRenderer.material = MaterialAzul;
                break;
            case "Dorado":
                pinzaRenderer.material = MaterialDorado;
                break;
            case "Amatista":
                pinzaRenderer.material = MaterialAmatista;
                break;
            default:
                pinzaRenderer.material = MaterialRojo;
                break;
        }
    }
}




