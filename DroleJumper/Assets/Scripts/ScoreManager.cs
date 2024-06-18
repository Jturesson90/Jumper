using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public Transform playerTransform;
    private float scoreY;

    private TMP_Text text;

    // Use this for initialization
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        score = 0;
        scoreY = playerTransform.transform.position.y;
    }

    private void Update()
    {
        UpdateScore();
        text.SetText(score.ToString());
    }

    private void UpdateScore()
    {
        if (scoreY < playerTransform.position.y * 9.5f)
        {
            scoreY = playerTransform.position.y * 9.5f;
        }

        score = (int)scoreY;
    }
}