using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlide : MonoBehaviour
{
    [SerializeField] private Transform rightDoor;
    [SerializeField] private Transform rightDoor2;
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform leftDoor2;
    private Vector3 rightDoorPos;
    private Vector3 rightDoorPos2;
    private Vector3 leftDoorPos;
    private Vector3 leftDoorPos2;

    private Vector3 rightDoorOri;
    private Vector3 leftDoorOri;
    private Vector3 rightDoorOri2;
    private Vector3 leftDoorOri2;

    private void Start()
    {
        rightDoorPos = rightDoor.position;
        leftDoorPos = leftDoor.position;
        rightDoorPos2 = rightDoor2.position;
        leftDoorPos2 = leftDoor2.position;

        rightDoorOri = rightDoor.position;
        leftDoorOri = leftDoor.position;
        rightDoorOri2 = rightDoor2.position;
        leftDoorOri2 = leftDoor2.position;
    }

    private void Update()
    {
        rightDoor.position = Vector3.Slerp(rightDoor.position, rightDoorPos, 1*Time.deltaTime);
        leftDoor.position = Vector3.Slerp(leftDoor.position, leftDoorPos, 1 * Time.deltaTime);
        leftDoor2.position = Vector3.Slerp(leftDoor2.position, leftDoorPos2, 1 * Time.deltaTime);
        rightDoor2.position = Vector3.Slerp(rightDoor2.position, rightDoorPos, 1 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rightDoorPos = new Vector3(rightDoorPos.x , rightDoorPos.y, rightDoorPos.z + 5);
            rightDoorPos2 = new Vector3(rightDoorPos2.x , rightDoorPos2.y, rightDoorPos2.z + 5);
            leftDoorPos = new Vector3(leftDoorPos.x , leftDoorPos.y, leftDoorPos.z - 5);
            leftDoorPos2 = new Vector3(leftDoorPos2.x , leftDoorPos2.y, leftDoorPos2.z - 5);

            this.GetComponent<AudioSource>().Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        rightDoorPos = rightDoorOri;
        rightDoorPos2 = rightDoorOri2;
        leftDoorPos = leftDoorOri;
        leftDoorPos2 = leftDoorOri2;
    }




}
