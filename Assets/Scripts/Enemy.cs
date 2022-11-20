using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float deathTime = 0.25f;

    public GameObject drop;
    public GameObject dropSpawnPosition;

    private Transform target;
    [SerializeField] private int health;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
    public void TakeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(deathTime);
        gameObject.SetActive(false);
        if (drop != null)
        {
            Instantiate(drop, dropSpawnPosition.transform.position, Quaternion.identity);
        }

    }
}
