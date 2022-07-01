using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager _scoreManagerInstance;
    public TextMeshProUGUI score;
    //public BoxCollider enemyGoal;
    public List<Image> playerLives;
    private int remainingLives = 3;
    private int i_score;

    void Awake()
    {
        if(_scoreManagerInstance != null)
            Destroy(this);
        else
            _scoreManagerInstance = this;

        DontDestroyOnLoad(this);
    }

    void Update() 
    {
        score.text = i_score.ToString();
    }

    public void DecreaseLives()
    {
        playerLives[remainingLives - 1].color = Color.gray;
        remainingLives -= 1;

        if(remainingLives == -1)
            EndGame();
    }

    public void IncreaseScore()
    {
        i_score++;
    }

    private void EndGame()
    {
        Debug.Log("Game has ended");
    }
}
