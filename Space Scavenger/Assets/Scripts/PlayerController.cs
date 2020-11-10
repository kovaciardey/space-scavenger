using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 10f;
    public float lookSpeed = 10f;

    public GameObject debugCube;

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
        LookAtMouse();

        // Nu tine cont de faptul ca se apasa pe click atunci cand canFire = false

        if ((Input.GetButton("IsometricRight") || Input.GetButton("IsometricUp")) && !Input.GetButton("Fire1"))
        {
            MoveCharacter();
        }

        DebugForward();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.ToString());

        if (other.gameObject.tag == "Monster")
        {
            GetComponent<HealthController>().ApplyDamage(other.gameObject.GetComponent<MonsterController>().GetDamage());
        }

        if (other.gameObject.tag == "HealthPickUp")
        {
            GetComponent<HealthController>().ApplyHealth(other.gameObject.GetComponent<PickUpController>().GetLifeAdded());
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "AmmoPickUp")
        {
            GetComponent<AmmoController>().AddAmmo(other.gameObject.GetComponent<AmmoPickUpController>().GetAmmoAdded());
            Destroy(other.gameObject);
        }
    }

    private void MoveCharacter()
    {
        Vector3 rightMovement = sideVector * walkSpeed * Time.deltaTime * Input.GetAxis("IsometricRight");
        Vector3 upMovement = upVector * walkSpeed * Time.deltaTime * Input.GetAxis("IsometricUp");

        Vector3 movement = rightMovement + upMovement;
        Vector3 direction = movement.normalized;

        //TODO: Look At the speed when moving diagonally

        //TODO: don't allow movement while shooting

        //transform.forward = direction;
        characterController.Move(movement);

        //gameObject.transform.Translate(movement + direction);

        //GetComponent<Rigidbody>().position = transform.position + movement;
    }

    private void LookAtMouse()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitdist = 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            // HACK

            Vector3 targetPoint = ray.GetPoint(hitdist);

            //Debug.Log(targetPoint);
            GameObject debug = Instantiate(debugCube, targetPoint, Quaternion.identity);

            transform.LookAt(debug.GetComponent<Transform>());

            Destroy(debug);
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
