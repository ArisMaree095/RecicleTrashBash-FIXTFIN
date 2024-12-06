using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public int Coin = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Coin")
        {
            Coin++;
            coinText.text = "Monedas: " + Coin.ToString();
            Debug.Log(Coin);
            Destroy(other.gameObject); //Para dar la ilusion

           PlayerPrefs.SetInt("Monedas", Coin);
            PlayerPrefs.Save();
        }
    }
}
