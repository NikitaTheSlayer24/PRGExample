using UnityEngine;

public class TreantEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;

    public void Died()
    {
        Instantiate(_coinPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.6f);
    }
}
