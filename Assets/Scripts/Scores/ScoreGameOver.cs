using UnityEngine;
using UnityEngine.UI;

public class ScoreGameOver : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private ScoreKepeer _scoreKepeer;

    private void Awake()
    {
        _scoreKepeer = FindObjectOfType<ScoreKepeer>();
    }

    private void Start()
    {
        _scoreText.text = "You scored : \n" + _scoreKepeer.GetScore().ToString();
    }
}
