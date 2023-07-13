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

    private float charger = 15; // ?arj?r
    private float ammo = 60; // M?himmat
    private float chargerCapacity = 15;
    void Start()
    {
        cam = Camera.main;
        healthController = this.gameObject.GetComponent<CharacterController>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthController.isAlive() == true)
        {
            if (Input.GetMouseButton(0))
            {
                if (charger > 0)
                {
                    anim.SetBool("Fire", true);
                }
                if (charger <= 0)
                {
                    anim.SetBool("Fire", false);
                }
            }
            else if (charger <= 0 && ammo > 0)
            {
                anim.SetBool("changeCharger", true);
            }
            else
            {
                anim.SetBool("Fire", false);
            }
        }
    }

    public void ChangeCharger()
    {
        ammo -= chargerCapacity;
        charger = chargerCapacity;
        anim.SetBool("changeCharger", false);
    }

    public void Fire()
    {
        if (charger > 0)
        {
            charger--;
            muzzleFlash.Play();
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, zombieLayer))
            {
                hit.collider.gameObject.GetComponent<Zombie>().takeDamage();
            }
        }
    }

    public float GetCharger()
    {
        return charger;
    }
    public float GetAmmo()
    {
        return ammo;
    }
}
