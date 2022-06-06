using System;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public int damage;
    public void Seek(Transform _target)
    {
        target = _target;
    }
    public void Damage(int _damage)
    {
        damage = _damage;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized*distanceThisFrame,Space.World);
    }

    private void HitTarget()
    {
        EnemyController enemy = target.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
