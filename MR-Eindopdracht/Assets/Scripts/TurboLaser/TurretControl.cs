using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TurretControl : MonoBehaviour
{
    private List<GameObject> targets = new List<GameObject>();
    [SerializeField]
    private string targetTag = "Target";
    [SerializeField]
    private float searchDelay = 0.5f;
    public bool CanFire { get; set; }
    public GameObject Target { get; set; }

    private void Start()
    {
        this.CanFire = true;
        StartCoroutine(FindClosestTarget());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag(this.targetTag))
        {
            this.targets.Add(other.transform.root.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.targets.Contains(other.transform.root.gameObject))
        {
            this.targets.Remove(other.transform.root.gameObject);
        }
    }

    public void ToggleCanFire()
    {
        CanFire = !CanFire;
    }

    IEnumerator FindClosestTarget()
    {
        while (true)
        {
            float distance = float.MaxValue;
            GameObject closest = null;
            
            foreach(GameObject target in this.targets)
            {
                if (target == null)
                    continue;
                float targetDistance = Vector3.Distance(target.transform.position, this.transform.position);
                if (targetDistance < distance)
                {
                    distance = targetDistance;
                    closest = target;
                }
            }
            this.Target = closest;
            yield return new WaitForSeconds(this.searchDelay);
        }
    }
}
