using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Pawn : PieceClass
{
    bool case1, case2, case3, case4, case5, case6, case7, case8;
    bool isPromotable = false;
    public int myPasso = 0;

    public override void move()
    {
        if(type == "plt")
        {
            case4 = (movementCounter == 0) && (isEmpty((int)(position_old.x), (int)(position_old.y + 2)) && isEmpty((int)(position_old.x), (int)(position_old.y + 4)) && (position_old.y + 4 == transform.position.y && position_old.x == transform.position.x));

            case1 = (isEmpty((int)(position_old.x), (int)(position_old.y + 2)) && (position_old.y + 2 == transform.position.y && position_old.x == transform.position.x));
            if (position_old.y != 14 && position_old.x != 0)
            {
                if (!isEmpty((int)(position_old.x - 2), (int)(position_old.y + 2)))
                {
                    case2 = (position_old.y + 2 == transform.position.y && position_old.x - 2 == transform.position.x);
                }
            }
            if (position_old.y != 14 && position_old.x != 14)
            {
                if (!isEmpty((int)(position_old.x + 2), (int)(position_old.y + 2)))
                {
                    case3 = (position_old.y + 2 == transform.position.y && position_old.x + 2 == transform.position.x);
                }
            }
            string searchRight = "pdt " + (position_old.x + 2) + " " + (position_old.y);
            string searchLeft = "pdt " + (position_old.x - 2) + " " + (position_old.y);
            GameObject otherPawnRight = GameObject.Find(searchRight);
            GameObject otherPawnLeft = GameObject.Find(searchLeft);

            if(otherPawnRight != null )
            {
                case5 = (totalMoveCounter - 1 == otherPawnRight.GetComponent<Pawn>().myPasso && otherPawnRight.GetComponent<Pawn>().movementCounter == 1 && otherPawnRight.GetComponent<Pawn>().transform.position.y == 8);
            }
            if (otherPawnLeft != null)
            {
                case6 = (totalMoveCounter - 1 == otherPawnLeft.GetComponent<Pawn>().myPasso && otherPawnLeft.GetComponent<Pawn>().movementCounter == 1 && otherPawnLeft.GetComponent<Pawn>().transform.position.y == 8);
            }

            if (case5)
            {
                case7 = (position_old.y + 2 == transform.position.y && position_old.x + 2 == transform.position.x);
                if (case7)
                {
                    Pieces.PiecesBoard[(int)(position_old.y) / 2, (int)(position_old.x + 2) / 2] = "emp";
                }
            }
            if (case6)
            {
                case8 = (position_old.y + 2 == transform.position.y && position_old.x - 2 == transform.position.x);
                if (case8)
                {
                    Pieces.PiecesBoard[(int)(position_old.y) / 2, (int)(position_old.x - 2) / 2] = "emp";
                }
                    
            }
            if (case1 || case2 || case3 || case4 || case5 || case7 || case8)
            {

            }
            else
            {
                illegal = true;
                transform.position = position_old;
            }

            if (transform.position.y == 14)
            {
                isPromotable = true;

            }
            if (case4)
            {
                myPasso = totalMoveCounter;
            }
            if (isPromotable)
            {
                dropdown.enableWhite();

                StartCoroutine(waitForSelectionWhite());
            }


            case1 = false;
            case2 = false;
            case3 = false;
            case4 = false;
            case5 = false;
            case6 = false;
            case7 = false;
            case8 = false;
        }
        else if (type == "pdt")
        {
            case4 = (movementCounter == 0) && (isEmpty((int)(position_old.x), (int)(position_old.y - 2)) && isEmpty((int)(position_old.x), (int)(position_old.y - 4)) && (position_old.y - 4 == transform.position.y && position_old.x == transform.position.x));

            case1 = (isEmpty((int)(position_old.x), (int)(position_old.y - 2)) && (position_old.y - 2 == transform.position.y && position_old.x == transform.position.x));
            if (position_old.y != 0 && position_old.x != 0)
            {
                if (!isEmpty((int)(position_old.x - 2), (int)(position_old.y - 2)))
                {
                    case2 = (position_old.y - 2 == transform.position.y && position_old.x - 2 == transform.position.x);
                }
            }
            if (position_old.y != 0 && position_old.x != 14)
            {
                if (!isEmpty((int)(position_old.x + 2), (int)(position_old.y - 2)))
                {
                    case3 = (position_old.y - 2 == transform.position.y && position_old.x + 2 == transform.position.x);
                }
            }


            string searchRight = "plt " + (position_old.x + 2) + " " + (position_old.y);
            string searchLeft = "plt " + (position_old.x - 2) + " " + (position_old.y);
            GameObject otherPawnRight = GameObject.Find(searchRight);
            GameObject otherPawnLeft = GameObject.Find(searchLeft);
            if (otherPawnRight != null)
            {
                case5 = (totalMoveCounter - 1 == otherPawnRight.GetComponent<Pawn>().myPasso && otherPawnRight.GetComponent<Pawn>().movementCounter == 1 && otherPawnRight.GetComponent<Pawn>().transform.position.y == 6);
            }
            if (otherPawnLeft != null)
            {
                case6 = (totalMoveCounter - 1 == otherPawnLeft.GetComponent<Pawn>().myPasso && otherPawnLeft.GetComponent<Pawn>().movementCounter == 1 && otherPawnLeft.GetComponent<Pawn>().transform.position.y == 6);
            }

            if (case5)
            {
                case7 = (position_old.y - 2 == transform.position.y && position_old.x + 2 == transform.position.x);
                if (case7)
                {
                    Pieces.PiecesBoard[(int)(position_old.y) / 2, (int)(position_old.x + 2) / 2] = "emp";
                }
                    
            }
            if (case6)
            {
                case8 = (position_old.y - 2 == transform.position.y && position_old.x - 2 == transform.position.x);
                if (case8)
                {
                    Pieces.PiecesBoard[(int)(position_old.y) / 2, (int)(position_old.x - 2) / 2] = "emp";
                }
                    
            }
            if (case1 || case2 || case3 || case4 || case5 || case7 || case8)
            {

            }
            else
            {
                illegal = true;
                transform.position = position_old;
            }
            if (case4)
            {
                myPasso = totalMoveCounter;
            }


            case1 = false;
            case2 = false;
            case3 = false;
            case4 = false;
            case5 = false;
            case6 = false;
            case7 = false;
            case8 = false;

            if (transform.position.y == 0)
            {
                isPromotable = true;

            }

            if (isPromotable)
            {
                dropdown.enableBlack();

                StartCoroutine(waitForSelectionBlack());
            }
        }
    }
    IEnumerator waitForSelectionWhite()
    {
        yield return new WaitUntil(() => ChoosePromotionDropdown.promtionName != null);
       
        pieces.GeneratePromotion((int)transform.position.x, (int)transform.position.y, ChoosePromotionDropdown.promtionName);
        dropdown.disable ();
        ChoosePromotionDropdown.promtionName = null;
        
        Destroy(transform.gameObject);
    }
    IEnumerator waitForSelectionBlack()
    {
        yield return new WaitUntil(() => ChoosePromotionDropdown.promtionName != null);

        pieces.GeneratePromotion((int)transform.position.x, (int)transform.position.y, ChoosePromotionDropdown.promtionName);
        dropdown.disable();
        ChoosePromotionDropdown.promtionName = null;        
        //updateArr(type);
        //temp[(int)transform.position.y, (int)transform.position.x] = ChoosePromotionDropdown.promtionName;
        //checkAndMateCheck(Pieces.PiecesBoard);
        //Destroy(transform.gameObject);
    }
    public override void showLegael(Transform transform)
    {
        if(type == "pdt")
        {   
            if (position_old.y != 0)
            {
                if (isEmpty((int)(position_old.x), (int)(position_old.y - 2)))
                    showTile((int)position_old.x, (int)position_old.y - 2, GridThatShow);
                if (position_old.x != 0)
                    if (!isEmpty((int)(position_old.x - 2), (int)(position_old.y - 2)))
                        if (transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(position_old.y - 2) / 2, (int)(position_old.x - 2) / 2][1])
                            showTile((int)position_old.x - 2, (int)position_old.y - 2, GridThatShowDeath);
                if (position_old.x != 14)
                    if (!isEmpty((int)(position_old.x + 2), (int)(position_old.y - 2)))
                        if (transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(position_old.y - 2) / 2, (int)(position_old.x + 2)/2][1])
                            showTile((int)position_old.x + 2, (int)position_old.y - 2, GridThatShowDeath);
                if ((movementCounter == 0) && isEmpty((int)(position_old.x), (int)(position_old.y - 2)) && isEmpty((int)(position_old.x), (int)(position_old.y - 4)))
                    showTile((int)position_old.x, (int)position_old.y - 4, GridThatShow);
            }
            string searchRight = "plt " + (position_old.x + 2) + " " + (position_old.y);
            string searchLeft = "plt " + (position_old.x - 2) + " " + (position_old.y);
            GameObject otherPawnRight = GameObject.Find(searchRight);
            GameObject otherPawnLeft = GameObject.Find(searchLeft);
            if (otherPawnRight != null)
            {
                case5 = (totalMoveCounter - 1 == otherPawnRight.GetComponent<Pawn>().myPasso && otherPawnRight.GetComponent<Pawn>().movementCounter == 1 && otherPawnRight.GetComponent<Pawn>().transform.position.y == 6);
            }
            if (otherPawnLeft != null)
            {
                case6 = (totalMoveCounter - 1 == otherPawnLeft.GetComponent<Pawn>().myPasso && otherPawnLeft.GetComponent<Pawn>().movementCounter == 1 && otherPawnLeft.GetComponent<Pawn>().transform.position.y == 6);
            }

            if (case5)
            {
                showTile((int)(position_old.x + 2), (int)(position_old.y - 2), GridThatShowDeath);

            }
            if (case6)
            {
                showTile((int)(position_old.x - 2), (int)(position_old.y - 2), GridThatShowDeath);

            }
        }
        else if (type == "plt")
        {
            if (position_old.y != 14)
            {
                if (isEmpty((int)(position_old.x), (int)(position_old.y + 2)))
                    showTile((int)position_old.x, (int)position_old.y + 2, GridThatShow);
                if (position_old.x != 0)
                    if (!isEmpty((int)(position_old.x - 2), (int)(position_old.y + 2)))
                        if (transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(position_old.y + 2) / 2, (int)(position_old.x - 2) / 2][1])
                            showTile((int)position_old.x - 2, (int)position_old.y + 2, GridThatShowDeath);
                if (position_old.x != 14)
                    if (!isEmpty((int)(position_old.x + 2), (int)(position_old.y + 2)))
                        if (transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(position_old.y + 2) / 2, (int)(position_old.x + 2) / 2][1])
                            showTile((int)position_old.x + 2, (int)position_old.y + 2, GridThatShowDeath);
                if ((movementCounter == 0) && isEmpty((int)(position_old.x), (int)(position_old.y + 2)) && isEmpty((int)(position_old.x), (int)(position_old.y + 4)))
                    showTile((int)position_old.x, (int)position_old.y + 4, GridThatShow);
            }
            string searchRight = "pdt " + (position_old.x + 2)  + " " + (position_old.y);
            string searchLeft = "pdt " + (position_old.x - 2)  + " " + (position_old.y) ;
            GameObject otherPawnRight = GameObject.Find(searchRight);
            GameObject otherPawnLeft = GameObject.Find(searchLeft);

            if (otherPawnRight != null)
            {
                case5 = (totalMoveCounter - 1 == otherPawnRight.GetComponent<Pawn>().myPasso && otherPawnRight.GetComponent<Pawn>().movementCounter == 1 && otherPawnRight.GetComponent<Pawn>().transform.position.y == 8);
            }
            if (otherPawnLeft != null)
            {
                case6 = (totalMoveCounter - 1 == otherPawnLeft.GetComponent<Pawn>().myPasso && otherPawnLeft.GetComponent<Pawn>().movementCounter == 1 && otherPawnLeft.GetComponent<Pawn>().transform.position.y == 8);
            }

            if (case5)
            {
                showTile((int)(position_old.x + 2), (int)(position_old.y + 2), GridThatShowDeath);
            }
            if (case6)
            {
                showTile((int)(position_old.x - 2), (int)(position_old.y + 2), GridThatShowDeath);

            }
        }
    }
}
