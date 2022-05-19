using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private GameObject _hitEffect;

    public int GetDamage()
    {
        return _damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.4f);
    }
}
