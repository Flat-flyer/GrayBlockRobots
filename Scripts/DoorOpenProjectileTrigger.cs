using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenProjectileTrigger : MonoBehaviour
{
    [SerializeField]
    private ProjectileTrigger projTrigger;
    [SerializeField]
    private GameObject activatedObject;
    [SerializeField]
    private bool Inverted;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Inverted == false)
        {
            if (projTrigger.Activated == true)
            {
                activatedObject.gameObject.SetActive(false);
            }
            if (projTrigger.Activated == false)
            {
                activatedObject.gameObject.SetActive(true);
            }
        }
        if (Inverted == true)
        {
            if (projTrigger.Activated == true)
            {
                activatedObject.gameObject.SetActive(true);
            }
            if (projTrigger.Activated == false)
            {
                activatedObject.gameObject.SetActive(false);
            }
        }
    }
}
