using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ButtonEvent : MonoBehaviour
{
    public TurretControl turretControl;

   public void onPress(Hand hand)
   {
        turretControl.ToggleCanFire();
        Debug.Log("SteamVR hover button was pressed");
   }
}
