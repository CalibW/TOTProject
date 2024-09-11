// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;
// public class EnemyController : MonoBehaviour
// {

//     public float lookRadius;
//     Transform target;
//     NavMeshAgent agent;
//     Animator animator;
//     // Start is called before the first frame update
//     void Start()
//     {
//         target = PlayerManager.instance.player.transform;
//         agent = GetComponent<NavMeshAgent>();
//         animator = GetComponent<Animator>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         animator.SetFloat("Speed", agent.velocity.magnitude);
//         float distance = Vector3.Distance(target.position, transform.position);
//         if (distance <= lookRadius)
//         {
//             agent.destination = target.position;
//         }

//         if (distance <= agent.stoppingDistance)
//         {
//             FaceTarget();
//         }
       
//     }

//     void FaceTarget()
//     {
//         Vector3 direction = (target.position - transform.position).normalized;
//         Quaternion lookRotation =  Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
//         transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
//     }

//     void OnDrawGizmosSelected ()
//     {
//         Gizmos.color = Color.red;
//         Gizmos.DrawWireSphere(transform.position, lookRadius);
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius;
    Transform target;
    NavMeshAgent agent;
    Animator animator;

    // Add reference to the enemy's attack value
    [SerializeField] private EnemyAttributes enemyAttributes;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Ensure enemyAttributes is set
        if (enemyAttributes == null)
        {
            enemyAttributes = GetComponent<EnemyAttributes>();
        }
    }

    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.destination = target.position;
        }

        if (distance <= agent.stoppingDistance)
        {
            FaceTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player is colliding
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerAttributes playerAttributes = collision.gameObject.GetComponent<PlayerAttributes>();
            if (playerAttributes != null)
            {
                // Reduce the player's health based on the enemy's attack
                playerAttributes.TakeDamage(enemyAttributes.attack);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}