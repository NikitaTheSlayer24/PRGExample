using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float _sceneLoadDelay = 2f;

    private ScoreKepeer _scoreKepeer;

    private void Awake()
    {
        _scoreKepeer = FindObjectOfType<ScoreKepeer>();
    }

    public void LoadGame()
    {
        _scoreKepeer.ResetScore();
        SceneManager.LoadScene("Level_1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("EndGame", _sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    private IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
