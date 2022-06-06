using UnityEngine;

public class ScoreKepeer : MonoBehaviour
{
    private int _score;

    private static ScoreKepeer _instance;   //œ≈–≈ƒ≈À¿“‹ —“¿“» ”!!!!!!!!!!!!!!!!!!

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (_instance != null)
        {
            Debug.Log("22");
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("33");
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return _score;
    }

    public void ModifyScore(int value)
    {
        _score = value;
        Mathf.Clamp(_score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
