using UnityEngine;

public class TreantEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;

    public void Destroy()
    {
        Instantiate(_coinPrefab, transform.position, Quaternion.identity);
    }
}
