using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    /*public KeyCode up;
    public KeyCode down;*/
    [SerializeField] public Rigidbody2D myRB;
    [SerializeField] public float speed = 5f;
    [SerializeField] public float limitSuperior;
    [SerializeField] public float limitInferior;
    [SerializeField] public int player_lives = 4;
    [SerializeField] public CustomInput verticalMovementAction = null;
    [SerializeField] public Vector2 movementMap; 

    // Start is called before the first frame update
    void Awake()
    {
        verticalMovementAction = new CustomInput();


        /*if (up == KeyCode.None) up = KeyCode.UpArrow;
        if (down == KeyCode.None) down = KeyCode.DownArrow;*/
        myRB = GetComponent<Rigidbody2D>();
        SetMinMax();
    }

    private void OnEnable()
    {
        verticalMovementAction.Enable();
        verticalMovementAction.Game.Movement.performed += OnMovementPerformed;
        verticalMovementAction.Game.Movement.canceled += OnMovementCanceled;
        
    }

    private void OnDisable()
    {
        verticalMovementAction.Disable();
        verticalMovementAction.Game.Movement.performed -= OnMovementPerformed;
        verticalMovementAction.Game.Movement.canceled -= OnMovementCanceled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext obj)
    {
        movementMap = obj.ReadValue<Vector2>();
    }
    private void OnMovementCanceled(InputAction.CallbackContext obj)
    {
        movementMap = Vector2.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 movementPlayer = new Vector2(movementMap.x, movementMap.y);
        myRB.velocity = movementPlayer * speed;

        



        /*if (Input.GetKey(up) && transform.position.y < limitSuperior)
        {
            myRB.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetKey(down) && transform.position.y > limitInferior)
        {
            myRB.velocity = new Vector2(0f, -speed);
        }
        else
        {
            myRB.velocity = Vector2.zero;
        }*/
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y;
        limitSuperior = bounds.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }
        if (other.tag == "Vehicle")
        {
            VehicleGenerator.instance.ManageVehicle(other.gameObject.GetComponent<VehicleController>(), this);
        }
    }
}
