using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private RotationWeapon _weaponPrefab;

    private Rigidbody2D _rb;
    private Camera _camera;
    private Animator _animator;
    private RotationWeapon _rotationWeapon;
    private Vector2 _movement;
    
    private void Start()
    {
        _camera = Camera.main;
        _animator = GetComponent<Animator>();
        _rotationWeapon = GetComponent<RotationWeapon>();
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
        _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);
    }
}
