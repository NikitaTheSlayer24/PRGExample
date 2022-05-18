using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private int _damage = 2;

    private void Update()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);

        //if (collision.collider.TryGetComponent(out IDamageable damageable))
        //{
        //    damageable.ApplyDamage(_damage);
        //}

        if (collision.collider.TryGetComponent(out TreantEnemy damageable))
        {
            damageable.ApplyDamage(_damage);
        }

        Destroy(effect, 0.4f);
        Destroy(gameObject);
    }
}
