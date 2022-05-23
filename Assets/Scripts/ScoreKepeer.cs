using UnityEngine;

public class ScoreKepeer : MonoBehaviour
{
    private int _score;

    private static ScoreKepeer _instance;   //���������� �������!!!!!!!!!!!!!!!!!!

    private void Awake()
    {
        
    }

    private void ManageSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
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
        _score += value;
        Mathf.Clamp(_score, 0, int.MaxValue);
        Debug.Log(_score);
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
