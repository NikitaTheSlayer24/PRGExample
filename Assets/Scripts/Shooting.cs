using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletForce = 20f;

    private GameObject _bullet;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        _bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = _bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
        rb.velocity = transform.up * _bulletForce;
    }
}
