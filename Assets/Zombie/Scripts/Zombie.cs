using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    public float zombieHP = 100;
    Animator anim;
    bool zombiDead;
    float distance;

    GameObject targetPlayer;
    public float attackDistance;
    NavMeshAgent zombieNavMesh;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        targetPlayer = GameObject.Find("Agent");
        zombieNavMesh = this.GetComponent<NavMeshAgent>();
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

        else
        {
            distance = Vector3.Distance(this.transform.position, targetPlayer.transform.position);
            if(distance < attackDistance)
            {
                zombieNavMesh.SetDestination(targetPlayer.transform.position);
            }
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
