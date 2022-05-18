using UnityEngine;

public class RotationWeapon : MonoBehaviour
{
    private Vector3 _mousePosition;
    private Vector2 _lookDirection;
    private Camera _camera;

    private float _positionZ;

    public Vector2 MouseDirection { get => _lookDirection; }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        _lookDirection = _mousePosition - transform.position;
        _positionZ = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f,0f, _positionZ);
    }
}
