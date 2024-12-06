using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funda : MonoBehaviour

{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Basura recogida");
            FindObjectOfType<Spawner>().RecogerBasura();
            Destroy(gameObject);
        }
    }
}
