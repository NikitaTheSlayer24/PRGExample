using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action CoinDestroy;
    public static event Action HearthDestroy;

    public static void OnCoinDestroy()
    {
        CoinDestroy?.Invoke();
    }

    public static void OnHealthDestroy()
    {
        HearthDestroy?.Invoke();
    }
}
