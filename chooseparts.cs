using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.AssemblyQualifiedNameParser;

public class chooseparts : MonoBehaviour
{
    public GameObject mention, auction, reversed, guess,allrounds,teamsinfo;
    public TextMeshProUGUI textmention, textauction, textreversed, textguess;
    public List<GameObject> parts = new List<GameObject>();
    public bool ismention, isauction, isreversed, isguess;
    private int currentPartIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        ismention=false;
    }
    public void Toggle1()
    {
        ismention = !ismention;
        selectmention(ismention,mention);
    }
    public void Toggle2()
    {
        isauction = !isauction;
        selectmention(isauction,auction);
    }
    public void Toggle3()
    {
        isreversed = !isreversed;
        selectmention(isreversed,reversed);
    }
    public void Toggle4()
    {
        isguess = !isguess;
        selectmention(isguess,guess);
    }
    int index = 0;
    public void selectmention(bool isSelected, GameObject gameObject)
    {
        if (isSelected)
        {
            if (!parts.Contains(gameObject))
            {
                parts.Add(gameObject);
                index = parts.Count;
            }
        }
        else
        {
            if (parts.Contains(gameObject))
            {
                parts.Remove(gameObject);
                index = parts.Count;
            }
        }
        UpdateTextMeshes();
    }
    public void nextpage()
    {
        this.gameObject.SetActive(false);
        teamsinfo.SetActive(true);
    }
    public void yalla()
    {
        UpdateGameObjectsVisibility();
    }
    private void UpdateGameObjectsVisibility()
    {
        for (int i = 0; i < parts.Count; i++)
        {
            parts[i].SetActive(i == currentPartIndex);
            this.gameObject.SetActive(false);
        }
    }

    private void UpdateTextMeshes()
    {
        textmention.text = parts.Contains(mention) ? (parts.IndexOf(mention) + 1).ToString() : "";
        textauction.text = parts.Contains(auction) ? (parts.IndexOf(auction) + 1).ToString() : "";
        textreversed.text = parts.Contains(reversed) ? (parts.IndexOf(reversed) + 1).ToString() : "";
        textguess.text = parts.Contains(guess) ? (parts.IndexOf(guess) + 1).ToString() : "";
    }
    public void NextPart()
    {
        if (currentPartIndex < parts.Count - 1)
        {
            currentPartIndex++;
            UpdateGameObjectsVisibility();
        }
    }
    public bool IsAtEnd()
    {
        Debug.Log("atend");
        return currentPartIndex >= parts.Count - 1;
    }
    public void PreviousPart()
    {
        if (currentPartIndex > 0)
        {
            currentPartIndex--;
            UpdateGameObjectsVisibility();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        
        
        
    }
}
