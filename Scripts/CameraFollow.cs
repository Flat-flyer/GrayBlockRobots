using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    public float clampAngle = 00.0f;
    public float inputSensitivity = 150.0f;
    public GameObject CameraObject;
    public GameObject PlayerObject;
    public float mouseX; 
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    [SerializeField]
    private float rotationY = 0.0f;
    [SerializeField]
    private float rotationX = 0.0f;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject Camera;
    private Quaternion localRotation;
    private Vector3 rotation;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotationY = rot.y;
        rotationX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Controller Rotation Setup
        //float inputX = Input.GetAxis("RightStickHorizontal");
        //float inputZ = Input.GetAxis("RightStickVertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX =  mouseX;
        finalInputZ = mouseY;

            rotationY += finalInputX * inputSensitivity * Time.deltaTime;
            rotationX += finalInputZ * inputSensitivity * Time.deltaTime;

            rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);

            localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
            transform.rotation = localRotation;
    }

    void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        //sets the followed object
        Transform target = CameraFollowObj.transform;

        //moves towards the target game object
        float step = CameraMoveSpeed * Time.deltaTime;


            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

}
