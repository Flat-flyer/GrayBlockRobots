using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    [SerializeField]
    private float jumpForce = 7;
    [SerializeField]
    private float groundDistance = 0.2f;
    [SerializeField]
    private float ProjectileSpeed = 8f;
    [SerializeField]
    private float HoverTime = 4f;


    public LayerMask groundLayers;

    private Rigidbody rb;
    [SerializeField]
    private Transform groundChecker;

    [SerializeField]
    private GameObject CameraRot;
    [SerializeField]
    private PlayerController Player;
    [SerializeField]
    private GameObject Projectile;
    [SerializeField]
    private Collider PlayerInteractor;

    [SerializeField]
    private GameObject BoostPack;
    [SerializeField]
    private GameObject HoverPack;
    [SerializeField]
    private GameObject InteractArm;
    [SerializeField]
    private GameObject ProjArm;

    public bool HasBoosterPack;
    public bool HasHoverPack;
    private bool HasJumped;
    public bool HasProjectileLauncher;
    public bool HasInteractArm;
    private Rigidbody Bullet;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundChecker = transform.GetChild(2);
    }

    public void Move (Vector3 PVelocity)
    {
        velocity = PVelocity;
    }

    public void Rotate (Vector3 PRotation)
    {
        rotation = PRotation;
    }

    private void Update()
    {
        if (HasHoverPack == true)
        {
            HoverPack.SetActive(true);
            BoostPack.SetActive(false);
        }
        else
        {
            HoverPack.SetActive(false);
        }
        if (HasProjectileLauncher == true)
        {
            ProjArm.SetActive(true);
            InteractArm.SetActive(false);
        }
        else
        {
            ProjArm.SetActive(false);
        }
        if (HasInteractArm == true)
        {
            ProjArm.SetActive(false);
            InteractArm.SetActive(true);
        }
        else
        {
            InteractArm.SetActive(false);
        }
        if (HasBoosterPack == true)
        {
            jumpForce = 10;
            BoostPack.SetActive(true);
            HoverPack.SetActive(false);
        }
        else
        {
            jumpForce = 7;
            BoostPack.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && Player.CanMove == true)
        {
            if (HasHoverPack == true)
            {
                rb.position = new Vector3(rb.position.x, rb.position.y + 0.2f, rb.position.z);
                rb.velocity.Set(rb.velocity.x, 0, rb.velocity.z);
                rb.useGravity = false;
                //StartCoroutine(EndHover(HoverTime, rb));
            }
            else
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.useGravity = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && HasProjectileLauncher == true)
        {
            var projectile = Instantiate(Projectile, Player.transform.position, Player.transform.rotation);
            Bullet = projectile.GetComponent<Rigidbody>();
            Bullet.velocity = CameraRot.transform.forward * ProjectileSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && HasInteractArm == true)
        {
            PlayerInteractor.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && HasInteractArm == true)
        {
            PlayerInteractor.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        rotation = new Vector3(0f, CameraRot.transform.rotation.eulerAngles.y, 0);
        PerformRotation();
        PerformMovement();

    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundChecker.position, groundDistance, groundLayers, QueryTriggerInteraction.Ignore);


    }

    //performs movement based on velocity varaible
    void PerformMovement ()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
    void PerformRotation()
    {
        rb.MoveRotation(Quaternion.Euler (rotation));
    }

    IEnumerator EndHover (float HoverTimer, Rigidbody player)
    {
        yield return new WaitForSeconds(HoverTimer);
        player.useGravity = true;
    }
}
