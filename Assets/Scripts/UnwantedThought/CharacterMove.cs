using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMove : MonoBehaviour
{

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    public UnityEvent tabrak, lari, tidak;

    public float Speed = 6.0f;
    public float rotateSpeed = 5f;
    private float y = 1f;

    // Use this for initialization
    void Start()
    {
        moveDirection = transform.forward;
        moveDirection = transform.TransformDirection(moveDirection);

        GameManager.Instance.GameState = GameState.Start;

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Instance.GameState)
        {
            case GameState.Start:
                var instance = GameManager.Instance;
                instance.GameState = GameState.Playing;
                break;
            case GameState.Playing:

                DetectDecellerateOrSwipeLeftRight();

                controller.Move(moveDirection * Speed * Time.deltaTime);

                break;
            case GameState.Dead:
                break;
            default:
                break;
        }

    }

    private void DetectDecellerateOrSwipeLeftRight()
    {
        if ((Input.GetKey(KeyCode.S)))
        {
            Speed -= 0.5f;
            Speed = Speed < 0 ? 0 : Speed;
        }
        else
        {
            Speed = 7.0f;
        }

        if ((Input.GetKeyUp(KeyCode.D)))
        {
            transform.Rotate(0, 90, 0);
            moveDirection = Quaternion.AngleAxis(90, Vector3.up) * moveDirection;
            
            //allow the user to swipe once per swipe location
            GameManager.Instance.CanSwipe = false;
        }
        else if ((Input.GetKeyUp(KeyCode.A)))
        {
            transform.Rotate(0, -90, 0);
            moveDirection = Quaternion.AngleAxis(-90, Vector3.up) * moveDirection;
            
            GameManager.Instance.CanSwipe = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
            lari.Invoke();
        else if(other.CompareTag("Home"))
            tabrak.Invoke();

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Block") || other.CompareTag("Home"))
            tidak.Invoke();
    }

}
