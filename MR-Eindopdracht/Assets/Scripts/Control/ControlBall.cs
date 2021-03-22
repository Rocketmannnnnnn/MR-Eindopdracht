using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBall : MonoBehaviour
{

    public int scale;

    public float readRotationSpeed;
    
    private Vector3 rotation;
    private Vector3 original;

    private GameObject controlBall;

    // Start is called before the first frame update
    void Start()
    {

        this.controlBall = GameObject.Find("Test-control-ball");
        this.original = this.controlBall.transform.position;

        Debug.Log("test!");

        StartCoroutine("checkBallPosition");
    }

    private IEnumerable checkBallPosition()
    {

        while (true)
        {

            this.rotation = new Vector3(0, 0, 0);

            if (Input.GetKeyDown(KeyCode.A)) this.rotation.x -= 1;
            if (Input.GetKeyDown(KeyCode.D)) this.rotation.x += 1;
            if (Input.GetKeyDown(KeyCode.S)) this.rotation.y -= 1;
            if (Input.GetKeyDown(KeyCode.W)) this.rotation.y += 1;
            if (Input.GetKeyDown(KeyCode.Q)) this.rotation.z -= 1;
            if (Input.GetKeyDown(KeyCode.E)) this.rotation.z += 1;

            this.controlBall.transform.position = (this.original + this.rotation);

            Debug.Log(this.rotation);

            yield return new WaitForSeconds(this.readRotationSpeed);
        }
    }
}
