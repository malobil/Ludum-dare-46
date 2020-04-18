using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float sensitivity = 5f;
    public Rigidbody rbCamera;
    public GameObject cam;

    private Vector2 movement;
    private PlayerInput inputs;
    private float xCameraRotation;
    private float yCameraRotation;

    private bool isRotating = false;

    private void Awake()
    {
        inputs = new PlayerInput();
        inputs.InGameInputs.RotateCamera.performed += ctx => StartRotation();
        inputs.InGameInputs.RotateCamera.canceled += ctx => EndRotation();
        inputs.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        xCameraRotation = cam.transform.rotation.eulerAngles.x;
        yCameraRotation = transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();

        if(isRotating)
        {
            CameraRotation();
        }
        
    }

    void CameraMove()
    {
        movement = inputs.InGameInputs.CameraMovement.ReadValue<Vector2>();
        Vector3 movementv3 = transform.right.normalized * movement.x + transform.forward.normalized * movement.y ;
        rbCamera.velocity = movementv3 * moveSpeed;
    }

    public void CameraRotation()
    {
        float mouseX = inputs.InGameInputs.MouseDelta.ReadValue<Vector2>().x * sensitivity * Time.deltaTime;
        float mouseY = inputs.InGameInputs.MouseDelta.ReadValue<Vector2>().y * sensitivity * Time.deltaTime;

        yCameraRotation += mouseX;
        xCameraRotation -= mouseY;
        xCameraRotation = Mathf.Clamp(xCameraRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(transform.localRotation.x, yCameraRotation, transform.localRotation.z);
        cam.transform.localRotation = Quaternion.Euler(xCameraRotation, cam.transform.localRotation.z, cam.transform.localRotation.z);
    }

    void StartRotation()
    {
        isRotating = true;
    }

    void EndRotation()
    {
        isRotating = false;
    }
}
