using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int score;

    public static Score instance;

    private void Awake()
    {
        instance = this;
    }

    public void Add(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
