using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletSpeed = 2;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Astroid"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<AstroidController>().TakeDamage();

        } else
        {
            Destroy(gameObject);
        }
    }
}
