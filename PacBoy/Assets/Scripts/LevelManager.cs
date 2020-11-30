using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [Space]

    [SerializeField]
    private Image[] heartImages;

    [Space]

    [SerializeField]
    private Vector2 playerStartingPosition;

    [Space]

    [SerializeField]
    private Ghost[] ghosts;

    private int score;

    private bool invincible;
    private const float INVINCIBILITY_TIME = 0.5f;

    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddToScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void SubtractHeart()
    {
        if (invincible)
            return;

        invincible = true;
        Invoke("ToggleOffInvincibility", INVINCIBILITY_TIME);

        for (int i = heartImages.Length - 1; i >= 0; i--)
        {
            if (!heartImages[i].enabled)
                continue;

            heartImages[i].enabled = false;

            if (i.Equals(0))
            {
                Time.timeScale = 0f; //Placeholder
                return;
            }

            ResetLevel();

            break;
        }
    }

    private void ResetLevel()
    {
        ResetPlayer();
        ResetGhosts();
    }

    private void ResetPlayer()
    {
        Player.instance.transform.position = playerStartingPosition;
        Player.instance.movePoint.position = playerStartingPosition;
    }

    private void ResetGhosts()
    {
        foreach (Ghost ghost in ghosts)
        {
            ghost.transform.position = ghost.startingPosition;
        }
    }
    
    private void ToggleOnTimeScale() => Time.timeScale = 1f;

    private void ToggleOffInvincibility() => invincible = false;
}
