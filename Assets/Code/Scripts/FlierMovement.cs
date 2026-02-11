using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlierMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;


    [Header("Attributes")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private int Damage = 1;
    private Transform target;

    private void Start()
    {
        target = LevelManager.main.path[LevelManager.main.path.Length - 1];

    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.LoseLife(Damage);
            Destroy(gameObject);
            return;
        }
    }
    private void FixedUpdate()
    {
        Vector2 dir = (target.position - transform.position).normalized;
        Vector2 movement = dir * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
