using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerBasura : MonoBehaviour
{
    private GameObject objectToGrab;
    private GameObject heldObject;
    public Transform holdPosition;

    void OnTriggerEnter(Collider other)
    {
        // Detecta si el objeto tiene los tags correspondientes
        if (other.CompareTag("Organico") || other.CompareTag("Metal") || other.CompareTag("Vidrio"))
        {
            objectToGrab = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (objectToGrab == other.gameObject)
        {
            objectToGrab = null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null && objectToGrab != null)
            {
                GrabObject();
            }
            else if (heldObject != null)
            {
                DropObject();
            }
        }
    }

    void GrabObject()
    {
        heldObject = objectToGrab;
        heldObject.transform.SetParent(holdPosition);
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void DropObject()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
    }

}
