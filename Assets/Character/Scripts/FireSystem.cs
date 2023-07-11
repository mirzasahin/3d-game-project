using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : MonoBehaviour
{
    Camera cam;
    public LayerMask zombieLayer;
    CharacterController healthController;
    Animator anim;
    public ParticleSystem muzzleFlash;
    void Start()
    {
        cam = Camera.main;
        healthController = this.gameObject.GetComponent<CharacterController>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthController.isAlive() == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("Fire", true);
            }
            else if(Input.GetMouseButtonUp(0))
            {
                anim.SetBool("Fire", false);
            }
        }
    }

    public void Fire()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, zombieLayer))
        {
            hit.collider.gameObject.GetComponent<Zombie>().takeDamage();
        }

    }
}
