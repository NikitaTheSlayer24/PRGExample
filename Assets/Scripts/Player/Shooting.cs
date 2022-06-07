using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _buleltLifeTime = 5f;
    [SerializeField] private float _firingRate = 0.2f;
    [SerializeField] private bool _isEnemy;

    private Coroutine _firingCoroutine;
    private GameObject _createBullet;

    private float _timeToNextBullet;
    private bool _isFiring;

    private void Start()
    {
        if (_isEnemy)
        {
            _isFiring = true;
        }
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;  //отключение выстрелов при нажатии на инвентарь

        Fire();

        if (Input.GetButtonDown("Fire1"))
        {
            _isFiring = true;
        }
        else if (_isEnemy)
        {
            _isFiring = false;
        }
    }

    public void IsFiring(bool value)
    {
        _isFiring = value;
    }

    private void Fire()
    {
        if (_isFiring && _firingCoroutine == null)
        {
            _firingCoroutine = StartCoroutine(FireContiniously());
            _isFiring = false;
        }
        else if (!_isFiring && _firingCoroutine != null)
        {
            StopCoroutine(_firingCoroutine);
            _firingCoroutine = null;
        }
    }

    private IEnumerator FireContiniously()
    {
        while (true)
        {
            _createBullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);

            Rigidbody2D rb = _createBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_firePoint.up * _bulletSpeed, ForceMode2D.Impulse);

            Destroy(_createBullet, _buleltLifeTime);
            _timeToNextBullet = _firingRate;

            yield return new WaitForSeconds(_timeToNextBullet);
        }
    }
}
