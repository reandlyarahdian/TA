using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMove : MonoBehaviour
{
    public float Speed = 6.0f;
    public float rotateSpeed = 5f;

    private float _Speed = 0f;
    private float _RotateSpeed = 0f;

    [SerializeField] Collider[] colliders;
    [SerializeField] GameObject particle;

    [SerializeField]UnityEvent kabur,
    tabrak,
    kanan,
    kiri,
    lurus,
    putarbalik;


    [SerializeField] private Check check;

    // Use this for initialization
    void Start()
    {
        GameManager.Instance.GameState = GameState.Start;
        check = Check.empty;
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

                break;
            case GameState.Dead:

                StartCoroutine(enumerator(1.5f));

                break;
            case GameState.Idle:
                _Speed = 0;
                break;
            default:
                break;
        }

    }

    private void DetectDecellerateOrSwipeLeftRight()
    {
        _Speed = Input.GetAxis("Vertical") * Speed;
        _RotateSpeed = Input.GetAxis("Horizontal");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3
            (0, _RotateSpeed * rotateSpeed * Time.deltaTime * Input.GetAxis("Vertical"), 0));
    }

    private void FixedUpdate()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * _Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (check == Check.tabrak)
            particle.SetActive(true);
        else if (check == Check.lurus)
            lurus.Invoke();
        else if (check == Check.kiri)
            kiri.Invoke();
        else if (check == Check.kanan)
            kanan.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Block"))
        {
            check = collision.gameObject.GetComponent<EnumStoring>().check;
            GameManager.Instance.GameState = GameState.Dead;
        }
    }

    IEnumerator enumerator(float num)
    {
        yield return new WaitForSeconds(num);
        SceneManager.LoadScene(9);
    }

    public void Menang()
    {
        GameManager.Instance.GameState = GameState.Idle;
        StartCoroutine(enumerator(5f));
    }
}
