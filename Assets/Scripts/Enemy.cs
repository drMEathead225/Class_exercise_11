using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {

    }



    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

}