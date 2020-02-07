using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenInteract : MonoBehaviour
{
    [SerializeField]
    private InteractArmTriggerObject InteractTrigger;
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
            if (InteractTrigger.Activated == true)
            {
                activatedObject.gameObject.SetActive(false);
            }
            if (InteractTrigger.Activated == false)
            {
                activatedObject.gameObject.SetActive(true);
            }
        }
        if (Inverted == true)
        {
            if (InteractTrigger.Activated == true)
            {
                activatedObject.gameObject.SetActive(true);
            }
            if (InteractTrigger.Activated == false)
            {
                activatedObject.gameObject.SetActive(false);
            }
        }
    }
}
