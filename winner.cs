using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winner : MonoBehaviour
{
    public Teamsinfo info;
    [SerializeField] private TextMeshProUGUI winnername, score;
    string team1name,team2name;
    int team1score,team2score;

    void Start()
    {
        team1name = PlayerPrefs.GetString("teamone");
        team2name = PlayerPrefs.GetString("teamtwo");
        team1score = PlayerPrefs.GetInt("score1");
        team2score = PlayerPrefs.GetInt("score2");
        if (team1score > team2score)
        {
            winnername.text=team1name;
            score.text=team1score.ToString();
        }else if (team1score < team2score)
        {
            winnername.text=team2name;
            score.text="Score : "+team2score.ToString();
        }
    }
    public void looby()
    {
        SceneManager.LoadScene(1);
    }
}
