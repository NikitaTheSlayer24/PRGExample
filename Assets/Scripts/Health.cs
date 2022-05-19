using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet damageDealer = collision.GetComponent<Bullet>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    private int GetHelath()
    {
        return _health;
    }

    private void TakeDamage (int damage)
    {
        _health -= damage;
        Debug.Log("Осталось " + _health + " здоровья");

        if (_health <= 0)
        {
            Debug.Log("Убит");
            Destroy(gameObject);
        }
    }
}
