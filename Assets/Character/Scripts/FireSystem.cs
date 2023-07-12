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

    private float charger = 5; // Þarjör
    private float ammo = 10; // Mühimmat
    private float chargerCapacity = 5;
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
                if (charger <= 0 && ammo > 0)
                {
                    anim.SetBool("changeCharger", true);
                }
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
}
