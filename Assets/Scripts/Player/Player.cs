using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private LevelManager _levelManager;
    private Bullet _bullet;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Destroy();
        }
        else if (collision.TryGetComponent(out HealthPoint healthPoint))
        {
            healthPoint.Destroy();
        }
    }

    public void Died()
    {
        _levelManager.LoadGameOver();
    }
}
