using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePromotionDropdown : MonoBehaviour
{
    public static string promtionName;
    public GameObject DropdownGameObjectWhite;
    public GameObject DropdownGameObjectBlack;
    public TMP_Dropdown dropdownWhite;
    public TMP_Dropdown dropdownBlack;
    public void enableWhite()
    {
        DropdownGameObjectWhite.SetActive(true);
        PieceClass.isDropdownActive= true;

    }
    public void enableBlack()
    {
        DropdownGameObjectBlack.SetActive(true);
        PieceClass.isDropdownActive = true;

    }
    public void disable()
    {
        DropdownGameObjectWhite.SetActive(false);
        DropdownGameObjectBlack.SetActive(false);
        dropdownWhite.SetValueWithoutNotify(0);
        dropdownBlack.SetValueWithoutNotify(0);
        PieceClass.isDropdownActive = false;
    }
    public void HandleInputDataWhite(int val)
    {

        switch (val)
        {
            case 0:
                promtionName = null;
                break;
            case 1:
                PieceClass.pointsWhite += 5;
                promtionName = "rlt";
                break;
            case 2:
                PieceClass.pointsWhite += 9;
                promtionName = "qlt";
                break;
            case 3:
                PieceClass.pointsWhite += 3;
                promtionName = "blt";
                break;
            case 4:
                PieceClass.pointsWhite += 3;
                promtionName = "nlt";
                break;
        }
    }
    public void HandleInputDataBlack(int val)
    {

        switch (val)
        {
            case 0:
                promtionName = null;
                break;
            case 1:
                PieceClass.pointsBlack += 5;
                promtionName = "rdt";
                break;
            case 2:
                PieceClass.pointsBlack += 9;
                promtionName = "qdt";
                break;
            case 3:
                PieceClass.pointsBlack += 3;
                promtionName = "bdt";
                break;
            case 4:
                PieceClass.pointsBlack += 3;
                promtionName = "ndt";
                break;
        }
    }
}
