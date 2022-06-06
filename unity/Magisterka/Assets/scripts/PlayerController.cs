using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerMovementControl playerMovement;
    private Animator animator;
    private PlayerStats stats;
    public string enemyTag = "enemy";
    public Transform target;
    public GameObject shootPrefab;
    public Transform firePoint;

    private void Awake()
    {
        playerMovement = new PlayerMovementControl();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        stats = GetComponent<PlayerStats>();
    }

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }
    private CharacterController controller;

    // Update is called once per frame
    void Update()
    {
        Vector2 input = playerMovement.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        if (input.x != 0 || input.y != 0)
        {
            animator.SetBool("isMoving", true);
            animator.SetBool("isAttacking", false);
            controller.Move(move * Time.deltaTime * stats.movementSpeed);

        }
        else {
            animator.SetBool("isMoving", false);
            if(target != null)
            {
                animator.SetBool("isAttacking", true);

            }
            else
            {
                animator.SetBool("isAttacking", false);
            }
        }
        if(input != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * stats.movementSpeed);
        }
        if(target != null && animator.GetBool("isAttacking"))
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = lookRotation.eulerAngles;
            PlayerManager.instance.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if (stats.attackCountdown <= 0)
            {
                Shoot();
                stats.attackCountdown = 1f / stats.attackSpeed;
            }
           
        }
        stats.attackCountdown -= Time.deltaTime;
        //if(target)
    }

    private void Shoot()
    {
        GameObject shootGameObject=(GameObject)Instantiate(shootPrefab, firePoint.position, firePoint.rotation);
        bulletScript bullet = shootGameObject.GetComponent<bulletScript>();
        if (bullet != null)
        {
            bullet.Seek(target);
            bullet.Damage(stats.attackPower);
        }

    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
    }
}
