using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Racks : MonoBehaviour
{
    public BoxCollider col;
    public GameObject Cart;
    public GameObject Items;
    public float price;

    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && Cart != null)
        {
            GameObject item = Instantiate(Items, Cart.transform.position + Vector3.up * 2f, Quaternion.identity);
            string names = item.name.Split('(')[0];
            Cart.GetComponent<Cart>().AddObject(names, price);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cart") && other.gameObject.GetComponent<Cart>())
        {
            Cart = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cart") && other.gameObject.GetComponent<Cart>())
        {
            Cart = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position + col.center, col.size);
    }
}
