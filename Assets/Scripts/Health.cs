using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 50;

    private Animator _animator;
    private EnemyPatrol _enemyPatrol;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

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
            StartCoroutine(DestroyObject());
            _enemyPatrol?.IsDead(true);
            _playerMovement?.IsDead(true);
            _animator.SetTrigger("IsDead");
        }
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
