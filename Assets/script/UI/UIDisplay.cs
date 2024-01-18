using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{

    //Health
    [SerializeField] Slider healthslider;
    [SerializeField] Health playerHealth;

    private GameObject player;

    //Score
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] ScoreKeeper scoreKeeper;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }

    void Start()
    {
        healthslider.maxValue = playerHealth.GetHealth();

    }

    
    void Update()
    {
        healthslider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString();

    }
}
