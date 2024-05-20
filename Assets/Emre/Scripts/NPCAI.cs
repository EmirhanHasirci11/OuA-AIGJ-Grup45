using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCAI : MonoBehaviour
{
    private Transform target;
    public GameObject sphere;
    private GameObject player;
    public Transform bulletSpawnPoint;

    public float followSpeed = 1.6f; 
    public float followDistance = 5.0f;

    public float attackCooldown = 5;
    private bool alreadyAttacked;

    public float bulletLifetime = 3.0f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        
        target = player.transform;
      
        Vector3 distance = target.position - transform.position;
        Vector3 horizontalDistance = new Vector3(distance.x, 0, distance.z);
        Vector3 followDirection = horizontalDistance.normalized;

        if (horizontalDistance.magnitude < followDistance)
            followDirection = distance.normalized;

        transform.position += followDirection * followSpeed * Time.deltaTime;
        AttackPlayer();

        
    }

    void AttackPlayer()
    {
        transform.LookAt(target);

        if (!alreadyAttacked)
        {
            

            Rigidbody rb = Instantiate(sphere, bulletSpawnPoint.position, bulletSpawnPoint.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 25f, ForceMode.Impulse);
            rb.AddForce(transform.up * 1f, ForceMode.Impulse);

            Destroy(rb.gameObject, bulletLifetime);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), attackCooldown);
 
        }
    }

    void ResetAttack()
    {
        alreadyAttacked= false;
    }
}