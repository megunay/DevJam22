using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject target;
    private bool detected;
    private float distance;
    private Vector2 targetpos;
    private float timeBetweenShots;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float cooldown;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float atackDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float chargespeed;
    [SerializeField] private int type;

    void Start()
    {
        timeBetweenShots = 0;
    }

    void Update()
    {
        timeBetweenShots += Time.deltaTime;
        if (detected) 
        {
            EnemyLogic();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            target = collision.gameObject;
            targetpos = target.GetComponent<Transform>().position;
            detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             detected = false;
        }
    }

    private void EnemyLogic() 
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance > atackDistance)
        {
            Move();
        }
        else if (distance <= atackDistance &&timeBetweenShots > cooldown) 
        {
            if (type == 1)
            {
                Charge();
            }
            else if (type == 2)
            {
                Shoot();
            }
            else if (type == 3)
            {
                Jump();
            }
        }
    }

    private void Move() 
    {
        Vector2 targetPosition = new Vector2(target.transform.position.x, target.transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void Charge() 
    {
        Vector2 targetPosition = new Vector2(target.transform.position.x, target.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetpos, chargespeed * Time.deltaTime);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        timeBetweenShots = 0;
        Vector2 direction = new Vector2(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y).normalized; 
        bullet.GetComponent<Rigidbody2D>().AddForce(-direction * bulletSpeed, ForceMode2D.Impulse);
    }

    private void Jump()
    {

    }
}
