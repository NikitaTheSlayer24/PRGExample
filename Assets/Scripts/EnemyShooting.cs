using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletForce = 10f;

    private float _currentTimeFiring;
    private float _startTimeFiring = 2f;

    private GameObject _bullet;
    private EnemyPatrol _enemyPatrol;
    private Vector2 _positionOfPlayerAtTimeOfAttack;

    private void Start()
    {
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _currentTimeFiring = _startTimeFiring;
    }

    private void FixedUpdate()
    {
        if (_currentTimeFiring <= 0)
        {
            Shoot();
            _currentTimeFiring = _startTimeFiring;
        }
        else
        {
            _currentTimeFiring -= Time.fixedDeltaTime;
        }
    }

    private void Shoot()
    {
        if (_enemyPatrol.IsAttack)
        {
            if (_enemyPatrol.Player == null) return;

            _bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);

            _positionOfPlayerAtTimeOfAttack = _enemyPatrol.Player.transform.position;
            Vector3 bulletRotation = _positionOfPlayerAtTimeOfAttack - (Vector2)_bullet.transform.position;
            float positionZ = Mathf.Atan2(bulletRotation.y, bulletRotation.x) * Mathf.Rad2Deg - 90f;
            _bullet.transform.rotation = Quaternion.Euler(0f, 0f, positionZ);

            Rigidbody2D rb = _bullet.GetComponent<Rigidbody2D>();
            rb.AddForce((_positionOfPlayerAtTimeOfAttack - (Vector2)_bullet.transform.position).normalized * _bulletForce, ForceMode2D.Impulse);
        }
    }
}
