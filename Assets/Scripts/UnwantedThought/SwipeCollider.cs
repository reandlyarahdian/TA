using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SwipeCollider : MonoBehaviour
{
    [SerializeField] UnityEvent enter, exit, col;
    // Use this for initialization
    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
            enter.Invoke();
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player"))
            exit.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            col.Invoke();
        }
    }
}
