using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCleanup : MonoBehaviour
{



    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 10f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerProjectile") == true)
        {
            Destroy(this.gameObject, 0.2f);
        }

    }
    }
