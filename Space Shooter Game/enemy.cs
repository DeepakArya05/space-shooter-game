using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
      // DamageDealer damageDealer = new DamageDealer();
        health = health - damageDealer.GetDamage();
        if(health<=0)
        {
             Destroy(gameObject);
            //damageDealer.hit();
        }
    }
}
