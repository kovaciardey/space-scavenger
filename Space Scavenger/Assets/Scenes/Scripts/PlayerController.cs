using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

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
        if(Input.anyKey)
        {
            MoveCharacter();
        }
    }

    private void MoveCharacter()
    {
        Vector3 rightMovement = sideVector * speed * Time.deltaTime * Input.GetAxis("IsometricRight");
        Vector3 upMovement = upVector * speed * Time.deltaTime * Input.GetAxis("IsometricUp");

        Vector3 movement = rightMovement + upMovement;
        Vector3 direction = movement.normalized;

        //TODO: Look At the speed when moving diagonally
 
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + direction * 4);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        transform.forward = direction;
        characterController.Move(movement);
    }
}
