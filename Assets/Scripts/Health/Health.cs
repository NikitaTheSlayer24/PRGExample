using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{   
    [SerializeField] private int _maxHealth = 50;
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _healthPoint = 20;

    private Animator _animator;
    private EnemyPatrol _enemyPatrol;
    private PlayerMovement _playerMovement;
    private TreantEnemy _treantEnemy;
    private Player _player;

    public event Action<float> HealthChanged;

    private bool _isDead = false;
    float _currentHealthAsPercent;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _playerMovement = GetComponent<PlayerMovement>();
        _treantEnemy = GetComponent<TreantEnemy>();
        _player = GetComponent<Player>();

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

        if (damageDealer != null && !_isDead)
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
            _isDead = true;
            _enemyPatrol?.IsDead(true);
            _playerMovement?.IsDead(true);
            _animator.SetTrigger("IsDead");
            HealthChanged?.Invoke(0);
            _treantEnemy?.Died();
            _player?.Died();
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
}
