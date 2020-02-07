using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float LookSensitivty = 150f;
    [SerializeField]
    private GameObject CameraFollowObject;
    [SerializeField]
    private GameObject BasicWheels;
    [SerializeField]
    private GameObject SpeedWheels;


    [SerializeField]
    private CameraFollow FollowCam;

    private Vector3 LastPlayerRotation;
    [SerializeField]
    private float TimePassed = 0f;
    private float SavedSpeed;

    private Transform FirstCollider;
    private Transform Player;
    private Animator PlayerAnimator;
    public bool CanMove = true;
    public bool HasSpeedWheels;
    private Vector3 MoveVertical;
    private Vector3 MoveHoritontal;



    private PlayerMotor motor;

    private void Start()
    {
        //gets components for the script to use from the player object and its children
        motor = GetComponent<PlayerMotor>();
        Player = GetComponent<Transform>();
        //PlayerAnimator = GetComponent<Animator>();
        //stores the base speed of the player
        SavedSpeed = speed;
    }

    private void Update()
    {

        //calculates movement velocity as a 3d vector
        float XMove = Input.GetAxisRaw("Horizontal");
        float ZMove = Input.GetAxisRaw("Vertical");

        Vector3 MoveHoritontal = transform.right * XMove;
        Vector3 MoveVertical = transform.forward * ZMove;

        Vector3 velocity = Vector3.zero;

        if (HasSpeedWheels == true)
        {
            speed = 7.5f;
            SpeedWheels.SetActive(true);
            BasicWheels.SetActive(false);
        }
        else
        {
            speed = SavedSpeed;
        }
        velocity = (MoveHoritontal + MoveVertical).normalized * speed;

        //apply movement
        if (CanMove == true)
        {
            motor.Move(velocity);
        }
        else
        {
            velocity = Vector3.zero;
            motor.Move(velocity);
        }


    }



}
