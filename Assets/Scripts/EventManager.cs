using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action CoinDestroy;

    public static void OnCoinDestroy()
    {
        CoinDestroy?.Invoke();
    }
}
