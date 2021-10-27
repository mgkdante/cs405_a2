using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{

    private NavMeshAgent agent;
    private int xPos;
    private int zPos;
    private int yPos;
    private Transform player;
    public Animator enemy;
    bool attack;
    public bool aggro;
    private WaitForSeconds activeframe = new WaitForSeconds(0.5f);
    private WaitForSeconds cd = new WaitForSeconds(2f);
    private WaitForSeconds wtime = new WaitForSeconds(3f);
    private bool bruh = false;
   // public Health health;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.updatePosition = true;
        player = GameObject.FindWithTag("Player").transform;
        changePosition();
    }

    void Update()
    {
        GoToTheNextPoint();
    }

    private void GoToTheNextPoint()
    {
        transform.position = agent.nextPosition;

        float rangeDistance = 15f;
        float attackRange = 3f;
        if (aggro == false) {
            if (Vector3.Distance(transform.position, player.position) <= rangeDistance)
            {
                aggro = true;
            }
            else
            {
                if (!agent.pathPending)
                {
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            changePosition();
                        }
                    }
                }

            }

        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) <= attackRange && attack == false)
            {
               // transform.LookAt(player.position);
                StartCoroutine("Attackanim");
                

                
            }
            else
            {
                if (attack == false && bruh == false)
                {
                    
                    StartCoroutine("changeDestination");
                }
                
            }
            
        }

        
    }
    IEnumerator Attackanim()
    {
        attack = true;
        enemy.SetBool("Attack", attack);
        transform.LookAt(player.position);
        yield return activeframe;
        attack = false;
        enemy.SetBool("Attack", attack);
        yield return cd;
    }
    IEnumerator changeDestination()
    {
        bruh = true;
        agent.destination = player.transform.position;
        yield return wtime;
        bruh = false;

    }
    private void changePosition()
    {
        xPos = Random.Range(20, 120);
        zPos = Random.Range(0, 120);
        agent.destination = new Vector3(xPos, 0, zPos);
    }
}