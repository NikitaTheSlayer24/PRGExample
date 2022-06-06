using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    private Text _scoreText;
    private ScoreKepeer _scoreKepeer;

    private int _score = 0;

    private void Awake()
    {
        _scoreKepeer = FindObjectOfType<ScoreKepeer>();
    }

    private void Start()
    {
        _scoreText = GetComponent<Text>();
        EventManager.CoinDestroy += ChangeScore;
    }

    private void OnDestroy()
    {
        EventManager.CoinDestroy -= ChangeScore;
    }

    public void ChangeScore()
    {
        _score++;
        _scoreText.text = "Score: " + _score;
        _scoreKepeer.ModifyScore(_score);
    }
}
