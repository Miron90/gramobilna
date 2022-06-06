using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    public EnemyStats stats;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        agent.SetDestination(target.position);

        if (distance <= agent.stoppingDistance)
        {
            AttackTarget();
            FaceTarget();
        }
    }

    
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime*5);
    }
    public void takeDamage(int damage)
    {
        stats.health -= damage;
        if (stats.health < 0) Destroy(gameObject);
    }
    private void AttackTarget()
    {
        throw new NotImplementedException();
    }

}
