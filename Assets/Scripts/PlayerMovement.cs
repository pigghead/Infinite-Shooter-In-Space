using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction fireAction;
    public GameObject laserPrefab;
    public GameObject laserSpawnPoint;
    private InputAction movement;
    public float speed = 0.75f;
    public List<AudioSource> _audioSrc;
    private Rigidbody rb;
    private float movX;
    private float movY;
    private bool coolDown = false;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;

        fireAction.performed += OnFire;
        fireAction.canceled += OnFire;
    }

    void OnEnable()
    {
        moveAction.Enable();
        fireAction.Enable();

    }

    void OnDisable()
    {
        moveAction.Disable();
        fireAction.Disable();
    }

    void FixedUpdate()
    {

    }

    void Update()
    {
        if(this.gameObject.transform.position.y <= -0.5f)
            gameObject.transform.position = new Vector3(transform.position.x, -0.5f, -7f);

        if(this.gameObject.transform.position.y >= 2.2f)
            gameObject.transform.position = new Vector3(transform.position.x, 2.2f, -7);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();

        rb.AddForce(direction * speed);

        if(direction.y == 0)
            rb.velocity = Vector3.zero;
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        var isPressed = context.ReadValue<float>();

        if(isPressed == 1 && !coolDown)
        {
            GameObject tempBullet = Instantiate(laserPrefab, laserSpawnPoint.transform.position, Quaternion.identity);
            _audioSrc[Random.Range(0, 2)].Play();
            coolDown = true;
            StartCoroutine(ResetCoolDown());
        }
    }

    IEnumerator ResetCoolDown()
    {
        yield return new WaitForSeconds(0.55f);
        coolDown = false;
    }
}
