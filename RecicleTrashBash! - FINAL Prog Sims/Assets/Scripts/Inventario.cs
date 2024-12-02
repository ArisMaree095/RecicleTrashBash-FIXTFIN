using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public List<GameObject> organic;
    public List<GameObject> metal;
    public List<GameObject> glass;

    public void AddToInventory(GameObject Spawner, string BasuraTipo)
    {
        switch (BasuraTipo)
        {
            case "organico":
                organic.Add(Spawner);
                Debug.Log($"Desecho organico");
                break;

            case "metal": 
                metal.Add(Spawner);
                Debug.Log($"Desecho metalico");
                break;

            case "vidrio":
                glass.Add(Spawner);
                Debug.Log($"Desecho de vidrio");
                break;

            default:
                Debug.LogWarning($"No hay basura");
                break;  
        }
    }
}
