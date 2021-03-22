using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLever : MonoBehaviour
{

    public int readLeverspeed;

    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {

        this.isActive = false;

        Debug.Log("testLever");

        StartCoroutine("checkLeverPulled");
    }

    IEnumerable checkLeverPulled()
    {

        while (true)
        {

            if (Input.GetKeyDown(KeyCode.Space)) this.isActive = !this.isActive;

            Debug.Log(this.isActive);

            yield return new WaitForSeconds(this.readLeverspeed);
        }
    }
}
