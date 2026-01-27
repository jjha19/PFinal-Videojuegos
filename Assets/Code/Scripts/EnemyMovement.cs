using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;


    [Header("Attributes")]
    [SerializeField] private float speed = 2f;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];

    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            pathIndex++;
            
            if(pathIndex >= LevelManager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            } else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 dir = (target.position - transform.position).normalized;
        Vector2 movement = dir * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
