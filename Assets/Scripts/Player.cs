using UnityEngine;

public class Player : MonoBehaviour
{
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
}
