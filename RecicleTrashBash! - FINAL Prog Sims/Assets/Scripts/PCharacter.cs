using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Elisbeth Matthew, 2023-1973
public class PCharacter : MonoBehaviour
{
    public float moveSpeed = 2.5f;       
    public float rotationSpeed = 100f; 
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Referencia al Rigidbody del personaje
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        // Movimiento hacia adelante y atrás
        float moveDirection = 0f;
        if (Input.GetKey(KeyCode.W)) moveDirection = 1f;
        else if (Input.GetKey(KeyCode.S)) moveDirection = -1f;

        // Mover en la dirección forward del objeto
        transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);

        // Rotación izquierda y derecha
        float rotationDirection = 0f;
        if (Input.GetKey(KeyCode.A)) rotationDirection = -1f;
        else if (Input.GetKey(KeyCode.D)) rotationDirection = 1f;

        // Rotar en el eje Y
        transform.Rotate(Vector3.up * rotationDirection * rotationSpeed * Time.deltaTime);

  
    }

    // Comprobar colisiones con el suelo para activar el salto
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }



}
