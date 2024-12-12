using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : Pickups
{
    public int hpValue = 1;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            base.OnTriggerEnter2D(collision);
            player.IncreaseHP(hpValue);
        }
    }
}
