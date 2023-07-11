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

    public CharacterController healthController;

    GameObject targetPlayer;
    public float attackDistance;
    public float attackAnimDistance;
    NavMeshAgent zombieNavMesh;
    private Rigidbody rb;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        targetPlayer = GameObject.Find("Agent");
        zombieNavMesh = this.GetComponent<NavMeshAgent>();
        rb = this.GetComponent<Rigidbody>();
        healthController = targetPlayer.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieHP <= 0)
        {
            zombiDead = true;
        }

        if (zombiDead)
        {
            anim.SetBool("ZombieDead", true);
            anim.SetBool("Run", false);
            anim.SetBool("Attack", false);
            StartCoroutine(Destroy());
        }

        if (healthController.isAlive() == false)
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Run", false);
            anim.SetBool("ZombieDead", false);
            anim.SetBool("Biting", true);
        }

        else
        {
            distance = Vector3.Distance(this.transform.position, targetPlayer.transform.position);
            if (distance < attackDistance && !zombiDead)
            {
                zombieNavMesh.isStopped = false;
                zombieNavMesh.SetDestination(targetPlayer.transform.position);
                anim.SetBool("Run", true);
                anim.SetBool("Attack", false);
                this.transform.LookAt(targetPlayer.transform.position);
            }
            else
            {
                zombieNavMesh.isStopped = true;
                anim.SetBool("Run", false);
                anim.SetBool("Attack", false);
            }
            if (distance < attackAnimDistance)
            {
                zombieNavMesh.isStopped = true;
                anim.SetBool("Run", false);
                anim.SetBool("Attack", true);
                this.transform.LookAt(targetPlayer.transform.position);
            }
        }
    }

    public void Damage()
    {
        targetPlayer.GetComponent<CharacterController>().takeDamage();
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
