using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth = 20;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(int damageValue)
    {
        _currentHealth -= damageValue;
        Debug.Log("� ��������� ������ �������� " + _currentHealth + " ��������");

        if (_currentHealth <= 0)
        {
            Debug.Log("�������� ������ ���������!");
            Destroy(gameObject);
        }
    }
}
