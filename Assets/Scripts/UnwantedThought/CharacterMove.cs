using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class CharacterMove : MonoBehaviour
{

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

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
                if (Input.GetMouseButtonUp(0))
                {
                    var instance = GameManager.Instance;
                    instance.GameState = GameState.Playing;
                }

                break;
            case GameState.Playing:

                DetectDecellerateOrSwipeLeftRight();

                controller.Move(moveDirection * Speed * Time.deltaTime);

                break;
            case GameState.Dead:
                if (Input.GetMouseButtonUp(0))
                {
                    //restart
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
            default:
                break;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.Die();
    }

    private void DetectDecellerateOrSwipeLeftRight()
    {
        if ((Input.GetKey(KeyCode.DownArrow)))
        {
            Speed -= 0.5f;
            Speed = Speed < 0 ? 0 : Speed;
        }
        else
        {
            Speed = 6.0f;
        }

        if (GameManager.Instance.CanSwipe &&
         (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Rotate(0, 90, 0);
            moveDirection = Quaternion.AngleAxis(90, Vector3.up) * moveDirection;
            
            //allow the user to swipe once per swipe location
            GameManager.Instance.CanSwipe = false;
        }
        else if (GameManager.Instance.CanSwipe &&
         (Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Rotate(0, -90, 0);
            moveDirection = Quaternion.AngleAxis(-90, Vector3.up) * moveDirection;
            
            GameManager.Instance.CanSwipe = false;
        }


    }





}
