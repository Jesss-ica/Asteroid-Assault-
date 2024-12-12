using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupUpgrade : Pickups
{
    public int upgradeValue = 1;
    public int scoreValue = 5;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            base.OnTriggerEnter2D(collision);
            wepons.AddGun(upgradeValue);
            gameManager.AddToScore(scoreValue);
        }
    }
}
