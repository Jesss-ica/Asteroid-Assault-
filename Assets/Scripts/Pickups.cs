using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickups : MonoBehaviour
{
    public ParticleSystem Particles;
    protected PlayerControllerRB player;
    protected WeponsManager wepons;
    protected GameManager gameManager;
    private AudioSource audioSource;
    // Start is called before the first frame update
    protected void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        wepons = FindObjectOfType<WeponsManager>();
        Invoke("DespawnPickup", 20f);
    }

    void DespawnPickup()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Particles.Stop();
            Destroy(gameObject, 1);
            player = collision.gameObject.GetComponent<PlayerControllerRB>();

        }

    }
}
