using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Elisbeth Matthew, 2023-1973
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Transform carryPoint;
    private List<GameObject> carriedItems = new List<GameObject>();

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        transform.Translate(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.G))
        {
            DropItems();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Item>(out Item item) && Input.GetKeyDown(KeyCode.F))
        {
            if (carriedItems.Count < 2)
            {
                PickUpItem(other.gameObject);
            }
        }
    }

    void PickUpItem(GameObject item)
    {
        item.transform.SetParent(carryPoint);
        item.transform.localPosition = Vector3.zero;
        carriedItems.Add(item);
        Debug.Log($"Picked up: {item.name}");
    }

    void DropItems()
    {
        foreach (GameObject item in carriedItems)
        {
            item.transform.SetParent(null);
        }
        carriedItems.Clear();
        Debug.Log("Dropped all items.");
    }
}
