using UnityEngine;
using UnityEditor;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 2.5f;
    [SerializeField] private float bps = 1f; //Balas por segundo
    [SerializeField] private AudioClip spawnSFX;
    [SerializeField] private AudioClip shootSFX;


    private Transform target;
    private float timeUntilFire = 0f;


    private void Awake()
    {
        AudioManager.main.PlaySFX(spawnSFX);
    }


    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        if(!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;
            if(timeUntilFire >= 1f / bps)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
        
    }

    private void Shoot()
    {

        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
        AudioManager.main.PlaySFX(shootSFX);
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, Vector3.forward, targetingRange);
        
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)
        transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
}
    