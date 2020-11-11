using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 10f;
    public float lookSpeed = 10f;

    public bool IsAlive { get; set; }

    public GameObject debugCube;

    private CharacterController characterController;
    private Camera mainCamera;

    private Vector3 upVector;
    private Vector3 sideVector;

    private LineRenderer lineRenderer;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        lineRenderer = gameObject.AddComponent<LineRenderer>();

        IsAlive = true;

        // get the camera object
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        // normalize the camera forward
        upVector = mainCamera.transform.forward.normalized;
        upVector.y = 0;

        // rotate the forward 90 degrees for sideways movement
        sideVector = Quaternion.Euler(0, 90, 0) * upVector;
    }

    void Update()
    {
        if (IsAlive)
        {
            LookAtMouse();

            if (Input.GetButton("Fire1") && GetComponent<Shooting>().GetCanFire())
            {
                GetComponent<Shooting>().Shoot();
            }

            if ((Input.GetButton("IsometricRight") || Input.GetButton("IsometricUp")) && !Input.GetButton("Fire1"))
            {
                MoveCharacter();
            }
        }

        DebugForward();
    }

    private void OnTriggerEnter(Collider other)
    {
        // apply monster damage when colliding with monster
        if (other.gameObject.tag == "Monster")
        {
            GetComponent<HealthController>().ApplyDamage(other.gameObject.GetComponent<MonsterController>().GetDamage());

            if (GetComponent<HealthController>().GetMaxHealthValue() == 0)
            {
                IsAlive = false;
            }
        }

        // apply bullet damage if player is hit by bullet shot by monster

        // there is a bug in this: the bullet triggers this event twice and the damage is added 2 times in the same frame to the player
        // will reduce the bullet damage in the editor for the prototype purposes
        // and I will debug this later

        if (other.gameObject.tag == "Bullet")
        {
            if (other.gameObject.GetComponent<BulletController>().GetOwner().gameObject.tag == "Monster")
            {
                GetComponent<HealthController>().ApplyDamage(other.gameObject.GetComponent<BulletController>().GetBulletDamage());

                Destroy(other.gameObject); // this is not working to resolve the bug

                if (GetComponent<HealthController>().GetMaxHealthValue() == 0)
                {
                    IsAlive = false;
                }
            }
        }

        // add health when colliding with a health pickUp
        if (other.gameObject.tag == "HealthPickUp")
        {
            GetComponent<HealthController>().ApplyHealth(other.gameObject.GetComponent<PickUpController>().GetLifeAdded());
            Destroy(other.gameObject);
        }

        // add ammo when colliding with ammo pickup
        if (other.gameObject.tag == "AmmoPickUp")
        {
            GetComponent<AmmoController>().AddAmmo(other.gameObject.GetComponent<AmmoPickUpController>().GetAmmoAdded());
            Destroy(other.gameObject);
        }

        // add the final scrap when "picking up" the ship reactor and disable any other interactions with it
        if (other.gameObject.tag == "Reactor")
        {
            if (!other.gameObject.GetComponent<ReactorController>().HasBeenClaimed)
            {
                other.gameObject.GetComponent<ReactorController>().HasBeenClaimed = true;

                other.gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;

                gameObject.GetComponent<ScrapController>().AddScrap(other.GetComponent<ReactorController>().ScrapAmount);
            }
        }
    }

    private void MoveCharacter()
    {
        // calculate up and right movement vectors
        Vector3 rightMovement = sideVector * walkSpeed * Time.deltaTime * Input.GetAxis("IsometricRight");
        Vector3 upMovement = upVector * walkSpeed * Time.deltaTime * Input.GetAxis("IsometricUp");

        // create the movement vector
        Vector3 movement = rightMovement + upMovement;

        // apply the movement
        characterController.Move(movement);
    }

    /**
     * The function to move rotate the player 
     * 
     * Generates a plane from the players position;
     * Casts a ray from the camera, 
     * Spawns a Cube at the location of the ray hit
     * Rotates the player to look at the spawned cube
     * Deletes the cube
     * 
     * It is a very hacky way to do the rotation, but at the time it was the fastest way of doing it
     */
    private void LookAtMouse()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitdist = 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        { 
            Vector3 targetPoint = ray.GetPoint(hitdist);

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
