using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class AstroidController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float HitPoints = 3.0f;
    public GameObject pickUp;
    public float randomThrustRange = 1;
    public float randomRotationRange = 1;
    private AudioSource AstroidExpload;

    void Start()
    {
        ApplyForce();
    }

    public void TakeDamage()
    {
        HitPoints--;
        if (HitPoints == 0)
        {
            DestroyAstroid(false);
        }
    }

    public void ApplyForce()
    {
        Vector2 travelSpeed = new Vector2(Random.Range(randomThrustRange, -randomThrustRange), Random.Range(randomThrustRange, -randomThrustRange));
        float randomRotation = Random.Range(randomRotationRange, -randomRotationRange);
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddRelativeForce(travelSpeed);
        rb2d.AddTorque(randomRotation);

    }

    public void DestroyAstroid(bool HitPlayer)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        AstroidExpload = gameObject.GetComponent<AudioSource>();
        AstroidExpload.Play();
        Destroy(gameObject, 1);
        if (HitPlayer == false)
        {
            Instantiate(pickUp, transform.position, transform.rotation);
        }
    }
}
