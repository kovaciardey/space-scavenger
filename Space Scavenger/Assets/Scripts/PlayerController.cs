using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 10f;
    public float lookSpeed = 10f;

    private CharacterController characterController;
    private Camera mainCamera;

    private Vector3 upVector;
    private Vector3 sideVector;

    private LineRenderer lineRenderer;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        lineRenderer = gameObject.AddComponent<LineRenderer>();

        // take the forward vector of the camera and normalize it for up direction
        upVector = mainCamera.transform.forward.normalized;
        upVector.y = 0;
        
        // rotate the up vector 90 degrees to the right for the sideways direction
        sideVector = Quaternion.Euler(0, 90, 0) * upVector;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            LookAtMouse();
        }

        if (
            Input.GetButton("IsometricRight") || Input.GetButton("IsometricUp")
            )
        {
            MoveCharacter();
        }

        DebugForward();
    }

    private void MoveCharacter()
    {
        Vector3 rightMovement = sideVector * walkSpeed * Time.deltaTime * Input.GetAxis("IsometricRight");
        Vector3 upMovement = upVector * walkSpeed * Time.deltaTime * Input.GetAxis("IsometricUp");

        Vector3 movement = rightMovement + upMovement;
        Vector3 direction = movement.normalized;

        //TODO: Look At the speed when moving diagonally
 
        transform.forward = direction;
        characterController.Move(movement);
    }

    private void LookAtMouse()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            targetPoint.y = 0;

            transform.forward = targetPoint;
        }
    }

    private void DebugForward()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + transform.forward * 4);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }
}
