using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    public void Destroy()
    {
        GetHealth();
        Destroy(gameObject);
    }

    private void GetHealth()
    {
        EventManager.OnHealthDestroy();
    }
}
