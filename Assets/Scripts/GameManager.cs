using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    int score;
    public GameObject gameOverPanel;

    public void Init()
    {
        ScrollingScript[] blocks = GameObject.FindObjectsOfType<ScrollingScript>();
        foreach (ScrollingScript block in blocks)
        {
            block.Init();
        }
        GameObject.FindObjectOfType<PlayerScript>().Init();
        InvokeRepeating("UpdateScore", 0.5f, 0.5f);
    }

    public void Stop()
    {
        ScrollingScript[] blocks = GameObject.FindObjectsOfType<ScrollingScript>();
        foreach (ScrollingScript block in blocks)
        {
            block.Stop();
        }
        GameObject.FindObjectOfType<PlayerScript>().Stop();
        CancelInvoke();
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateScore()
    {
        score += 10;
        GameObject.FindObjectOfType<Score>().UpdateScore(score);
    }
}
