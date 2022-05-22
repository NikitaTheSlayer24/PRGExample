using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _health.HealthChanged += SetHealth;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= SetHealth;
    }

    public void SetHealth(float health)
    {
        Debug.Log(health);
        _slider.value = health;
    }
}
