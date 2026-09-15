using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AITarget : MonoBehaviour
{
    public Transform target;
    public float AttackDistance;

    private NavMeshAgent m_Agent;
    private Animator m_Animator;
    private float m_Distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        m_Distance = Vector3.Distance(m_Agent.transform.position, target.position);
        if (m_Distance < AttackDistance)
        {
            m_Animator.SetBool("Attacking", true);
            m_Agent.isStopped = true;
        }
        else
        {
            m_Animator.SetBool("Attacking", false);
            m_Agent.isStopped = false;
            m_Agent.SetDestination(target.position);
        }
    }
}