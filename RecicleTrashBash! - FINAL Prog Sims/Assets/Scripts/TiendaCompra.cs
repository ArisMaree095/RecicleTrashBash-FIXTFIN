using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaCompra : MonoBehaviour
{
    public int playerCoins;
    public int inventario;
    public GameObject TiendaUI;

   /* public void CompraUpgrade()
    {
        int costo = 0;
        int espacioinventario = 0;

        switch (Mejora)
        {
            case "Azul":
                costo = 10;
                inventario = 3;
                break;

            case "Dorado":
                costo = 20;
                inventario = 6;
                break;

            case "Amatista":
                costo = 30;
                inventario = 10;
                break;
        }

        if (playerCoins >= costo)
        {
            playerCoins -= costo;
            //Aplicamos el switch
            ApplyUpgrade(inventario);
        }
        /*else
        {
            Debug.Log()
        }*/

       /* public void CloseShop()
    {
        shopUI.SetActive(false);
        Time.timescale = 1;
        Debug.Log($"Devuelta al juego");
    }

    
    }*/

}
