using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform _pathPrefab;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _chaseDistance = 5f;

    private Animator _animator;
    private GameObject _player;

    private List<Transform> _waypoints;
    private int _wayPointsIndex = 0;
    private bool _isAttack = false;
    private bool _isDead = false;
    private float directionX;
    private float directionY;

    public GameObject Player { get => _player; }

    public bool IsAttack { get => _isAttack; }

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _waypoints = GetWaypoints();
        transform.position = _waypoints[_wayPointsIndex].position;
    }

    private void FixedUpdate()
    {
        Attack();
        FollowPath();
    }

    public void IsDead(bool value)
    {
        _isDead = value;
    }

    private void Attack()
    {
        if (InAttackRangeOfPlayer())
        {
            directionX = _player.transform.position.x - transform.position.x;
            directionY = _player.transform.position.y - transform.position.y;

            _isAttack = true;
            _animator.SetFloat("AttackHorizontal", directionX);
            _animator.SetFloat("AttackVertical", directionY);
            _animator.SetFloat("AnimationStatus", 2);     //1 - walk, 2 - attack
        }
        else
        {
            _isAttack = false;
            _animator.SetFloat("AnimationStatus", 1);     //1 - walk, 2 - attack
        }
    }

    private void FollowPath()
    {
        if (_wayPointsIndex < _waypoints.Count && !_isAttack && !_isDead)
        {
            Vector3 targetPosition = _waypoints[_wayPointsIndex].position;
            float delta = _moveSpeed * Time.fixedDeltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            directionX = targetPosition.x - transform.position.x;
            directionY = targetPosition.y - transform.position.y;

            _animator.SetFloat("Horizontal", directionX);
            _animator.SetFloat("Vertical", directionY);
            _animator.SetFloat("AnimationStatus", 1);     //1 - walk, 2 - attack


            if (transform.position == targetPosition)
            {
                _wayPointsIndex++;
            }
        }
        else if (_isDead) return;
        else if (_wayPointsIndex < _waypoints.Count && _isAttack) return;
        else _wayPointsIndex = 0;
    }

    private List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in _pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    private bool InAttackRangeOfPlayer()
    {
        if (_player == null) return false;
        float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
        return distanceToPlayer < _chaseDistance;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _chaseDistance);
    }
}
