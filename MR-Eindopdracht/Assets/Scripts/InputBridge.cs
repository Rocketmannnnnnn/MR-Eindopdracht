using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBridge : MonoBehaviour
{
    public InputComponent moveX;
    public InputComponent moveY;
    public InputComponent moveZ;
    public InputComponent rotationX;
    public InputComponent rotationY;
    public InputComponent rotationZ;
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
        Vector3 motion = new Vector3(moveX?.GetNormalizedAxis() ?? 0, moveY?.GetNormalizedAxis() ?? 0, moveZ?.GetNormalizedAxis() ?? 0);
        Vector3 angular = new Vector3(rotationX?.GetNormalizedAxis() ?? 0, rotationY?.GetNormalizedAxis() ?? 0, rotationZ?.GetNormalizedAxis() ?? 0);
        this.controller.Move(motion);
        this.controller.Rotate(angular);
    }
}
