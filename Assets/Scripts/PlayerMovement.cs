using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private RotationWeapon _weaponPrefab;

    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 _movement;

    private bool _isDead = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("Horizontal", _weaponPrefab.MouseDirection.x);
        _animator.SetFloat("Vertical", _weaponPrefab.MouseDirection.y);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        if (!_isDead || _weaponPrefab == null)
        {
            _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            Destroy(_weaponPrefab.gameObject);
        }
    }

    public void IsDead(bool value)
    {
        _isDead = value;
    }
}
