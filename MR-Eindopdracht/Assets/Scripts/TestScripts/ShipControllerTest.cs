using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControllerTest : MonoBehaviour
{
    public IShipController controller;
    public string spaceshipTag = "Spaceship";

    // Start is called before the first frame update
    void Start()
    {
        GameObject spaceship = GameObject.FindGameObjectWithTag(this.spaceshipTag);
        this.controller = spaceship.GetComponent<IShipController>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3();
        movement.x = Input.GetKey(KeyCode.D) ? Time.fixedDeltaTime : Input.GetKey(KeyCode.A) ? -Time.fixedDeltaTime : 0;
        movement.y = Input.GetKey(KeyCode.E) ? Time.fixedDeltaTime : Input.GetKey(KeyCode.Q) ? -Time.fixedDeltaTime : 0;
        movement.z = Input.GetKey(KeyCode.W) ? Time.fixedDeltaTime : Input.GetKey(KeyCode.S) ? -Time.fixedDeltaTime : 0;
        this.controller.Move(movement);

        Vector3 rotation = new Vector3();
        rotation.x = Input.GetKey(KeyCode.I) ? Time.fixedDeltaTime : Input.GetKey(KeyCode.K) ? -Time.fixedDeltaTime : 0;
        rotation.y = Input.GetKey(KeyCode.L) ? Time.fixedDeltaTime : Input.GetKey(KeyCode.J) ? -Time.fixedDeltaTime : 0;
        rotation.z = Input.GetKey(KeyCode.U) ? Time.fixedDeltaTime : Input.GetKey(KeyCode.O) ? -Time.fixedDeltaTime : 0;
        this.controller.Rotate(rotation);
    }
}
