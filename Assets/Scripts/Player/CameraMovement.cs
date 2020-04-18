using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody rbCamera;

    private Vector2 movement;
    private PlayerInput inputs;

    private void Awake()
    {
        inputs = new PlayerInput();
        inputs.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement = inputs.InGameInputs.CameraMovement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 movementv3 = new Vector3(movement.x, 0f, movement.y);
        rbCamera.velocity = movementv3 * moveSpeed;
    }
}
