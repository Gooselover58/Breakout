using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] powerups;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject VictoryUI;
    public bool isGameActive;

    private void Start()
    {
        isGameActive = true;
        gameOverUI.SetActive(false);
    }

    public void spawnPowerup(Vector3 pos)
    {
        int shouldThisEvenHappen = Random.Range(0, 7);
        if (shouldThisEvenHappen == 4)
        {
            int randIndex = Random.Range(0, powerups.Length);
            Instantiate(powerups[randIndex], pos, Quaternion.identity);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void EndGame()
    {
        isGameActive = false;
        gameOverUI.SetActive(true);
    }

    public void WonGame()
    {
        isGameActive = false;
        VictoryUI.SetActive(true);
    }
}
