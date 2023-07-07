using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 targetDistance;
    [SerializeField]
    private float mouseSensivity;
    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.position + targetDistance, Time.deltaTime * 10);
        mouseX += Input.GetAxis("Mouse X") * mouseSensivity;
        mouseY += Input.GetAxis("Mouse Y") * mouseSensivity;
        this.transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
}

