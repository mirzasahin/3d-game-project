using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    private float characterSpeed;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);
        this.gameObject.transform.Translate(horizontal * characterSpeed * Time.deltaTime, 0, vertical * characterSpeed * Time.deltaTime);
    }
}
