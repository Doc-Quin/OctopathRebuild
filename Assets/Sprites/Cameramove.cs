using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Cameramove : MonoBehaviour
{
    //private Vector3 targetRotation;
    private float fieldOfView = 75.0f;
    public Transform player;
    private Camera cam;
    private Transform pos;
    private Vector3 Newpos;
    private Vector3 Newrot;
    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PositionC = player.transform.position;
        Newpos = new Vector3(PositionC.x, PositionC.y + 2, PositionC.z - 8);
        Newrot = pos.rotation.eulerAngles;
        pos.transform.position= Newpos;
        Vector3 currentRotation = pos.rotation.eulerAngles;
        pos.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z);
        cam.fieldOfView = fieldOfView;
    }
}
