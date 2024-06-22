using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;
public class Teamsinfo : MonoBehaviour
{
    public Questions questions;
    public Actpart actpart;
    public chooseparts chooseparts;
    //audio
    public AudioSource start, score, wrong;
    ///
    [SerializeField] private Text Team1name;
    [SerializeField] private Text Team2name;
    [SerializeField] public TextMeshProUGUI team1name,team2name, score1, score2, roundnumber;
    [SerializeField] private GameObject Mention, teams;
    public Text Team1name1 { get => Team1name; set => Team1name = value; }
    public bool next,right1,right2;
    //sscore
    public int team1score = 0;
    public int team2score = 0;
    public int roundnum = 1;

    //animation
    //[SerializeField] private AnimatorController animatorscoore1,animatorscore2;
    [SerializeField] private GameObject scoreanim1, scoreanim2;
    [SerializeField] private Animator animator1, animator2;




    public string getname1()
    {
        return team1name.text=Team1name.text;
    }
    public string getname2()
    {
        return team2name.text=Team2name.text;
    }
    public int finalscore = 0;
    public int score11()
    {
        return team1score;
    }
    public int score22()
    {
        return team2score;
    }
    void Start()
    {
        next = false;
        right1 = false;
        right2 = false;
        team1name.text = getname1();
        team2name.text = getname2();
    }


    void Update()
    {
        team1name.text = getname1();
        team2name.text = getname2();
        //team1name.text = PlayerPrefs.GetString("teamone");
        //team2name.text = PlayerPrefs.GetString("teamtwo");
        if (next)
        {
            anim(animator1, scoreanim1);
            anim(animator2, scoreanim2);
            score.Play();
            increaseScore1();
            increaseScore2();
            next = false;
        }
    }
    public void increaseScore1()
    {
        team1score++;
        score1.text = team1score.ToString();
    }
    public void increaseScore2()
    {
        team2score++;
        score2.text = team2score.ToString();
    }
    public void incresescore(int teamscore, TextMeshProUGUI textscore)
    {
        teamscore++;
        textscore.text = teamscore.ToString();
    }
    public void yalla()
    {
        
        if (Team1name.text != "" && Team2name.text != "")
        {
            teams.SetActive(false);
            chooseparts.yalla();
            Debug.Log(Team1name.text.ToString());
        }
        else
        {
            Debug.Log("nnot yalla");
        }
    }
    public void anim(Animator animator,GameObject scoreanim)
    {
        animator.SetTrigger("IsRight1");
        scoreanim.SetActive(true);
    }
    public void fillstrikes(GameObject[] strikes1, GameObject[] strikes2)
    {
        for (int i = 0; i < strikes1.Length; i++)
        {
            strikes1[i].SetActive(false);
        }
        for (int i = 0; i < strikes2.Length; i++)
        {
            strikes2[i].SetActive(false);
        }
    }
    public void strikes(GameObject[] strikes1,GameObject[] strikes2,int strikeindex,int strikenumber)
    {
        strikes2[strikeindex].SetActive(true);
        Debug.Log(strikeindex);
        wrong.Play();
        if (strikeindex == 2)
        {
            for (int i = 0; i < strikes2.Length; i++)
            {
                strikes2[i].SetActive(false);
            }
            for (int i = 0; i < strikes1.Length; i++)
            {
                strikes1[i].SetActive(false);
            }
            wrong.Stop();
            if (strikenumber == 2)
            {
                anim(animator1, scoreanim1);
                increaseScore1();
            }
            else if (strikenumber == 1) 
            {
                anim(animator2, scoreanim2);
                increaseScore2();
            }
            score.Play();
            questions.desabledbuttons();
            StartCoroutine(questions.ChangeQuestionAfterDelay(1.5f));
        }
    }
    public void strikesactpart(GameObject[] strikes1, GameObject[] strikes2, int strikeindex, int strikenumber)
    {
        strikes2[strikeindex].SetActive(true);
        Debug.Log(strikeindex);
        wrong.Play();
        if (strikeindex == 2)
        {
            for (int i = 0; i < strikes2.Length; i++)
            {
                strikes2[i].SetActive(false);
            }
            for (int i = 0; i < strikes1.Length; i++)
            {
                strikes1[i].SetActive(false);
            }
            wrong.Stop();
            if (strikenumber == 2)
            {
                anim(animator1, scoreanim1);
                increaseScore1();
            }
            else if (strikenumber == 1)
            {
                anim(animator2, scoreanim2);
                increaseScore2();
            }
            score.Play();
            actpart.desabledbuttons();
            StartCoroutine(actpart.ChangeQuestionAfterDelay(1.5f));
        }
    }
    public void setinfo()
    {
        PlayerPrefs.SetInt("score1", score11());
        PlayerPrefs.SetInt("score2", score22());
        PlayerPrefs.SetString("teamone", team1name.text);
        PlayerPrefs.SetString("teamtwo", team2name.text);
    }
    /////////////////////////////////////////auction
    ///
    public void Right(bool p1,bool p2)
    {
        score.Play();
        if (p1)
        {
            increaseScore1();
            anim(animator1, scoreanim1);
        }
        if (p2)
        {
            increaseScore2();
            anim(animator2, scoreanim2);
        }
    }
}
