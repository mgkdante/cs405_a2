using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public NavMeshAgent player;
    public Camera playerCamera;
    public Animator playerAnimation;
    bool move;
    private Transform enemy;
    public float attackRange = 1f;
    public BoxCollider lp;
    public BoxCollider rp;
    private WaitForSeconds activeframe = new WaitForSeconds(1f);
    public AudioSource spin;


    private void Start()
    {
        transform.position = GetComponent<NavMeshAgent>().nextPosition;
        enemy = GameObject.FindWithTag("Enemy").transform;
        lp.isTrigger = false;
        rp.isTrigger = false;
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        { 
            Ray myRay = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(myRay, out hit))
            {
                player.destination = hit.point;

                if(hit.transform.tag == "Enemy")
                {
                    if (enemy != null)
                    {
                            transform.LookAt(hit.transform.position);
                    }
                    if (Vector3.Distance(transform.position, hit.transform.position) <= 2)
                    {
                        Attack();
                    }
                }
            }
        }

        if (player.remainingDistance <= player.stoppingDistance)
        {
            move = false;
        }
        else
        {
            move = true;
        }

        playerAnimation.SetBool("move", move);
    }

    void Attack()
    {
        StartCoroutine("Attack_anim");
        playerAnimation.SetTrigger("Attack");
        spin.Play();
    }
    IEnumerator Attack_anim() {
        lp.isTrigger = true;
        rp.isTrigger = true;
        yield return activeframe;
        lp.isTrigger = false;
        rp.isTrigger = false;
    }
}
