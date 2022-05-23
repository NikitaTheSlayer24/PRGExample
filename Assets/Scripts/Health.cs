using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 50;
    [SerializeField] private int _healthPoint = 20;
    private int _currentHealth;
    float _currentHealthAsPercent;

    public event Action<float> HealthChanged;

    private Animator _animator;
    private EnemyPatrol _enemyPatrol;
    private PlayerMovement _playerMovement;
    private TreantEnemy _treantEnemy;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _playerMovement = GetComponent<PlayerMovement>();
        _treantEnemy = GetComponent<TreantEnemy>();

        _currentHealth = _maxHealth;

        EventManager.HearthDestroy += GetHealthPoint;
    }

    private void OnDestroy()
    {
        EventManager.HearthDestroy -= GetHealthPoint;
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

    private void GetHealthPoint()
    {
        if (_currentHealth >= _maxHealth) return;
        _currentHealth += _healthPoint;
        ChangeHealthbar();
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
            _treantEnemy.Destroy();
        }
        else
        {
            ChangeHealthbar();
        }
    }

    private void ChangeHealthbar()
    {
        _currentHealthAsPercent = _currentHealth / (float)_maxHealth;
        HealthChanged?.Invoke(_currentHealthAsPercent);
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
