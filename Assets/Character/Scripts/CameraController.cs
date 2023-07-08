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

    Vector3 objRot;
    Vector3 temp;
    public Transform characterSpine;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
        if(mouseY >= 40)
        {
            mouseY = 40;
        }

        if(mouseY <= -60)
        {
            mouseY = -60;
        }

        this.transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
        target.transform.eulerAngles = new Vector3(0, mouseX, 0);

        temp = this.transform.eulerAngles;
        temp.z = 0;
        temp.y = this.transform.localEulerAngles.y; // Unneccessary these 2 lines.
        temp.x = this.transform.localEulerAngles.x; // Unneccessary these 2 lines.
        objRot = temp;

        characterSpine.transform.eulerAngles = objRot;
        
        
    }   
}

