using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public float zombieHP = 100;
    Animator anim;
    bool zombiDead;
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(zombieHP <= 0)
        {
            zombiDead = true;
        }

        if(zombiDead)
        {
            anim.SetBool("ZombieDead", true);
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    public void takeDamage()
    {
        zombieHP -= Random.Range(15, 25);
    }
}
