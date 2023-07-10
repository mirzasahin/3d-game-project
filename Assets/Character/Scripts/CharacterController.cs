using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    private float characterSpeed;

    public float health = 100;
    bool isLive = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        isLive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            isLive = false;
            anim.SetBool("isLive", false);
        }
        if(isLive)
        {
            Movement();
        }

    }

    public bool isAlive()
    {
        return isLive;
    }

    public void takeDamage()
    {
        health -= Random.Range(15, 25);
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
