using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Qnumber;
    [SerializeField] private GameObject loading, qnum;
    private int QCounter = 2;
    public bool isactive=false;
    [SerializeField]private Button next;
    public int getQcounter()
    {
        return QCounter;
    }
    public void QIncrease()
    {
        if (QCounter < 10)
        {
            next.interactable = true;
            QCounter++;
            Qnumber.text = QCounter.ToString();
        }
    }
    public void QDecrease()
    {
        if (QCounter > 2)
        {
            if(QCounter == 3)
                next.interactable = false;        
            QCounter--;
            Qnumber.text = QCounter.ToString();
        }
    }
    public void Next()
    {
        qnum.SetActive(false);
        loading.SetActive(true);
        isactive = true;
    }
    private void Start()
    {
        next.interactable=false;
    }
}
