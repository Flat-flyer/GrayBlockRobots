using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private PlayerController player;
    private PlayerMotor PlayerMotor;
    [SerializeField]
    private int upgradeType = 0;
    private bool isActive;
    [SerializeField]
    private float respawnTimer;
    [SerializeField]
    private Collider PickupCollider;
    [SerializeField]
    private GameObject PickupModel;
    [SerializeField]
    private GameObject Wheels;
    [SerializeField]
    private GameObject BoostPack;
    [SerializeField]
    private GameObject HoverPack;
    [SerializeField]
    private GameObject ProjArm;
    [SerializeField]
    private GameObject InteractArm;
    [SerializeField]
    private GameObject Remove;
    // Start is called before the first frame update
    void Start()
    {
        if (upgradeType == 0)
        {
            Wheels.SetActive(true);
        }
        if (upgradeType == 1)
        {
            BoostPack.SetActive(true);
        }
        if (upgradeType == 2)
        {
            HoverPack.SetActive(true);
        }
        if (upgradeType == 3)
        {
            ProjArm.SetActive(true);
        }
        if (upgradeType == 4)
        {
            InteractArm.SetActive(true);
        }
        if (upgradeType == 5)
        {
            Remove.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PickupModel.transform.Rotate(new Vector3(0, 50 ,0) * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            PlayerMotor = other.GetComponent<PlayerMotor>();
            if (upgradeType == 0)
            {
                player = other.GetComponent<PlayerController>();
                player.HasSpeedWheels = true;
            }
            if (upgradeType == 1)
            {
                PlayerMotor.HasBoosterPack = true;
                if (PlayerMotor.HasHoverPack == true)
                {
                    PlayerMotor.HasHoverPack = false;
                }
            }
            if (upgradeType == 2)
            {
                PlayerMotor.HasHoverPack = true;
                if (PlayerMotor.HasBoosterPack == true)
                {
                    PlayerMotor.HasBoosterPack = false;
                }
            }
            if (upgradeType == 3)
            {
                PlayerMotor.HasProjectileLauncher = true;
                if (PlayerMotor.HasInteractArm == true)
                {
                    PlayerMotor.HasInteractArm = false;
                }
            }
            if (upgradeType == 4)
            {
                PlayerMotor.HasInteractArm = true;
                if (PlayerMotor.HasProjectileLauncher == true)
                {
                    PlayerMotor.HasProjectileLauncher = false;
                }
            }
            if (upgradeType == 5)
            {
                PlayerMotor.HasHoverPack = false;
                PlayerMotor.HasBoosterPack = false;
                PlayerMotor.HasInteractArm = false;
                PlayerMotor.HasProjectileLauncher = false;
            }
            PickupModel.SetActive(false);
            PickupCollider.enabled = false;
            StartCoroutine(RespawnPickup(respawnTimer));
        }
    }

    IEnumerator RespawnPickup (float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);
        PickupModel.SetActive(true);
        PickupCollider.enabled = true;
        isActive = true;
    }
}
