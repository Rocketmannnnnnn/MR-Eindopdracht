using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ButtonEvent : MonoBehaviour
{
    public TurretControl turretControl;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }


    private void Update()
    {
        if (turretControl.CanFire)
        {
            renderer.material.color = Color.green;
        }
        else
        {
            renderer.material.color = Color.red;
        }
    }

    public void onPress(Hand hand)
    {
        turretControl.ToggleCanFire();
        Debug.Log("SteamVR hover button was pressed");
    }

}
