using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private int _damage;

    public int GetDamage()
    {
        return _damage;
    }

    public void Damage(int damage)
    {
        _damage = damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet) 
            || collision.TryGetComponent(out HealthPoint healthPoint)
            || collision.TryGetComponent(out Coin coin)) return;

        GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.4f);
        Hit();
    }
}
