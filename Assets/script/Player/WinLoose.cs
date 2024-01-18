using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoose : MonoBehaviour
{
    private SceneManagement SceneManagement;
    private ScoreKeeper scoreKeeper;
    private Health playerHealth;
    private GameObject player;

    private void Awake()
    {
        SceneManagement = FindObjectOfType<SceneManagement>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
    }

    void Update()
    {
        if (player == null)
        {
            SceneManagement.SceneNum = 3;
            SceneManagement.GoNextScene();
        }

        if (scoreKeeper.GetScore() == 20)
        {
            SceneManagement.SceneNum = 2;
            SceneManagement.GoNextScene();
        }
    }
}
