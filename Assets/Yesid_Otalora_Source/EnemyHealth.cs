using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
    {
        private float health;
        private GameObject gameobject;
        public Animator enemyAnimation;

        private void Start()
        {
            health = 20f;
        }

        private void Update()
        {
        if (health <= 0f)
        {
            Die();
        }
    }

        void OnTriggerEnter(Collider obj)
        {
        if (gameObject != null)
        {
            if (obj.gameObject.tag == "AttackPoint")
            {
                health -= 5f;
            }
            }
        }

    void Die()
    {
        enemyAnimation.SetBool("Dead", true);
        GetComponent<Patrol>().enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<NavMeshAgent>().speed = 0;
        GetComponent<Rigidbody>().isKinematic = true;
       
    }
}