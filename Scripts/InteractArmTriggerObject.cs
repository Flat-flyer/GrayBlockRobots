using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractArmTriggerObject : MonoBehaviour
{
    public bool Activated;
    [SerializeField]
    private bool TimedActivation;
    [SerializeField]
    private float timer = 5f;
    private Collider TriggerCollider;

    private void Start()
    {
        TriggerCollider = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interact") == true)
        {
            Activated = true;
            if (TimedActivation == true)
            {
                StartCoroutine(activeCountdown(timer));
            }
            TriggerCollider.enabled = false;
        }
    }

    IEnumerator activeCountdown (float time)
    {
        yield return new WaitForSeconds(time);
        Activated = false;
        TriggerCollider.enabled = true;
    }
}
