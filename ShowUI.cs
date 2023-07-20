using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    public TMP_Text whiteScore;
    public TMP_Text blackScore;

    public TMP_Text winShow;
    public RawImage winShowBG;

    public GameObject checkWhite;
    public GameObject checkBlack;
    public void Update()
    {
        if(PieceClass.pointsWhite > PieceClass.pointsBlack)
        {
            whiteScore.GetComponent<TMP_Text>().text = "+" + (PieceClass.pointsWhite - PieceClass.pointsBlack).ToString();
            blackScore.GetComponent<TMP_Text>().text = "";
        }
        else if(PieceClass.pointsWhite < PieceClass.pointsBlack)
        {
            blackScore.GetComponent<TMP_Text>().text = "+" + (PieceClass.pointsBlack - PieceClass.pointsWhite).ToString();
            whiteScore.GetComponent<TMP_Text>().text = "";
        }
        else
        {
            blackScore.GetComponent<TMP_Text>().text = "";
            whiteScore.GetComponent<TMP_Text>().text = "";
        }
        
       
    }
    public void showWin(char won)
    {
        if(won == 'l')
        {
            winShowBG.gameObject.SetActive(true);
            winShow.color = Color.white;
            winShow.text = "White Won";
            winShowBG.color = Color.black;
        }else if(won == 'd')
        {
            winShowBG.gameObject.SetActive(true);
            winShow.color = Color.black;
            winShow.text = "Black Won";
            winShowBG.color = Color.white;
        }
    }
    public void showCheck(bool show, char colorChar)
    {
        if(colorChar == 'l')
        {
            checkWhite.SetActive(show);
        }
        else
        {
            checkBlack.SetActive(show);
        }
    }
}
