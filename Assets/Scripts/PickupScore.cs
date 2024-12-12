using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScore : Pickups
{

    public int scoreValue = 1;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            base.OnTriggerEnter2D(collision);
            gameManager.AddToScore(scoreValue);

        }
    }
}
