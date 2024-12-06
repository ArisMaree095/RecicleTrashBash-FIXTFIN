using UnityEngine;

public class BasuraPickUp : MonoBehaviour
{
    public Funda funda; // Referencia al inventario
    public Rigidbody rb;
    public BoxCollider coll;

    private void Start()
    {
        rb.isKinematic = false;
        coll.isTrigger = true; // Aseg�rate de que sea Trigger
    }

    private void OnTriggerEnter(Collider other)
    {
     
            if (other.CompareTag("Player"))
            {
                Debug.Log("Basura recogida");
                // A�adir la basura a la funda
                Destroy(gameObject); // Destruir basura tras recoger
            }
        
    }
}
