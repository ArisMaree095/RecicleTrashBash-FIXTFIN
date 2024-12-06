using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public class Monedas : MonoBehaviour
    {
        public int Valores = 0;

        void Start()
        {
            IncrementarValores();
        }

        void IncrementarValores()
        {
            for (int i = 0; i < 1; i++)
            {
                Valores += 0;
                Debug.Log("Valor Actual de las Monedas: " + Valores);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Monedas moneda = other.gameObject.GetComponent<Monedas>();
        if (moneda != null)
        {
            ValorMonedas += moneda.Valores;
            Debug.Log("Valor Actual de las Monedas: " + ValorMonedas);
            Destroy(other.gameObject);
        }
    }
    private int ValorMonedas;
}
