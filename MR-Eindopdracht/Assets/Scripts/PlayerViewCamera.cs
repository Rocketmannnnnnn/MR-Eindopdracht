using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform playerView;
    public Transform spaceView;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromView = playerCamera.position - spaceView.position;
        transform.position = playerView.position + playerOffsetFromView;
    }
}
