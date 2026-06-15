using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float time = 60f;
    public TextMeshProUGUI timerText;

    public GameObject gameOverUI;

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver)
            return;

        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
            isGameOver = true;

            gameOverUI.SetActive(true);

            StartCoroutine(RestartGame());
        }

        timerText.text = Mathf.Ceil(time).ToString();
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}