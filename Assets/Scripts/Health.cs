using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 50;
    private int _currentHealth;

    public event Action<float> HealthChanged;

    private Animator _animator;
    private EnemyPatrol _enemyPatrol;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _playerMovement = GetComponent<PlayerMovement>();

        _currentHealth = _maxHealth; 
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

    private void TakeDamage (int damage)
    {
        _currentHealth -= damage;
        Debug.Log("Осталось " + _currentHealth + " здоровья");

        if (_currentHealth <= 0)
        {
            Debug.Log("Убит");
            StartCoroutine(DestroyObject());
            _enemyPatrol?.IsDead(true);
            _playerMovement?.IsDead(true);
            _animator.SetTrigger("IsDead");
            HealthChanged?.Invoke(0);
        }
        else
        {
            float _currentHealthAsPercent = _currentHealth / (float)_maxHealth;
            HealthChanged?.Invoke(_currentHealthAsPercent);
        }

    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
