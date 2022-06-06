using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public void Destroy()
    {
        GetScore();
        Destroy(gameObject);
    }

    private void GetScore()
    {
        EventManager.OnCoinDestroy();
    }
}
