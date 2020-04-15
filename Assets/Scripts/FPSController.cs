using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private GameObject cam;

    public float horizontalSensitivity;
    public float verticalSensitivity;
    public float moveSpeed;

    private float rotationX=270;
    private float rotationY;

    private Rigidbody rbd;

    void Start()
    {
        rbd = this.GetComponent<Rigidbody>();
    }

    void Update()
    {

        cam.transform.position = new Vector3 (this.transform.position.x,this.transform.position.y+.5f,this.transform.position.z);

        rotationX += (Input.GetAxis("Mouse X") * Time.deltaTime) * horizontalSensitivity;
        rotationY += (Input.GetAxis("Mouse Y") * Time.deltaTime) * verticalSensitivity;
        rotationY = Mathf.Clamp(rotationY, -75.0f, 75.0f);


        float moveX = (Input.GetAxis("Horizontal") * Time.deltaTime) * moveSpeed;
        float moveY = (Input.GetAxis("Vertical") * Time.deltaTime) * moveSpeed;

        Vector3 movement = new Vector3(moveX, 0, moveY);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = moveSpeed - 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = moveSpeed + 2;
        }


        cam.transform.eulerAngles = new Vector3(-rotationY, rotationX, 0);
        this.transform.eulerAngles = new Vector3 (0, cam.transform.eulerAngles.y, 0);

        rbd.MovePosition(this.transform.position + transform.TransformDirection(movement));
    }

}
