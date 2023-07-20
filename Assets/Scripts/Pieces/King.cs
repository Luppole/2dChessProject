using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class King : PieceClass
{
    bool case1, case2, case3, case4, case5, case6, case7, case8, case9, case10, case11;

    public override void move()
    {
        if(type == "klt")
        {
            GameObject rookRight = GameObject.Find("rlt 14 0");
            GameObject rookLeft = GameObject.Find("rlt 0 0");
            if (rookRight != null)
            {
                if (rookRight.GetComponent<Rook>().movementCounter == 0 && movementCounter == 0)
                {
                    case9 = (transform.position.x == position_old.x + 4 && transform.position.y == position_old.y);
                    case11 = isEmpty(10, 0) && isEmpty(12, 0);
                    if (case9 && case11)
                    {
                        rookRight.GetComponent<Transform>().position = new Vector2(10, 0);
                        Pieces.PiecesBoard[0, 5] = "rlt";
                        Pieces.PiecesBoard[0, 7] = "emp";
                        sound.castling();
                    }
                }
            }
            if (rookLeft != null)
            {
                if (rookLeft.GetComponent<Rook>().movementCounter == 0 && movementCounter == 0)
                {
                    case10 = (transform.position.x == position_old.x - 6 && transform.position.y == position_old.y);
                    case11 = isEmpty(6, 0) && isEmpty(4, 0) && isEmpty(2, 0);
                    if (case10 && case11)
                    {
                        rookLeft.GetComponent<Transform>().position = new Vector2(4, 0);
                        Pieces.PiecesBoard[0, 2] = "rlt";
                        Pieces.PiecesBoard[0, 0] = "emp";
                        sound.castling();

                    }
                }
            }
        }else if(type == "kdt")
        {
            GameObject rookRight = GameObject.Find("rdt 14 14");
            GameObject rookLeft = GameObject.Find("rdt 0 14");
            if (rookRight != null)
            {
                if (rookRight.GetComponent<Rook>().movementCounter == 0 && movementCounter == 0)
                {
                    case9 = (transform.position.x == position_old.x + 4 && transform.position.y == position_old.y);
                    case11 = isEmpty(10, 14) && isEmpty(12, 14);
                    if (case9 && case11)
                    {
                        rookRight.GetComponent<Transform>().position = new Vector2(10, 14);
                        Pieces.PiecesBoard[7, 5] = "rdt";
                        Pieces.PiecesBoard[7, 7] = "emp";
                        sound.castling();

                    }
                }
            }
            if (rookLeft != null)
            {
                if (rookLeft.GetComponent<Rook>().movementCounter == 0 && movementCounter == 0)
                {
                    case10 = (transform.position.x == position_old.x - 6 && transform.position.y == position_old.y);
                    case11 = isEmpty(6, 14) && isEmpty(4,14) && isEmpty(2, 14);
                    if (case10 && case11)
                    {
                        rookLeft.GetComponent<Transform>().position = new Vector2(4, 14);
                        Pieces.PiecesBoard[7, 2] = "rdt";
                        Pieces.PiecesBoard[7, 0] = "emp";
                        sound.castling();
                    }
                }
            }
        }
        
        case1 = kingMove(0, 1);
        case2 = kingMove(0, -1);
        case3 = kingMove(1, 1);
        case4 = kingMove(1, 0);
        case5 = kingMove(1, -1);
        case6 = kingMove(-1, 0);
        case7 = kingMove(-1, 1);
        case8 = kingMove(-1, -1);

        
        if (!(case1 || case2 || case3 || case4 || case5 || case6 || case7 || case8 || case9 || case10))
        {
            transform.position = position_old;
        }

        case1 = false;
        case2 = false;
        case3 = false;
        case4 = false;
        case5 = false;
        case6 = false;
        case7 = false;
        case8 = false;
        case9 = false;
        case10 = false;
        case11 = false;

    }
    public bool kingMove(int xMul, int yMul)
    {
        return position_old.x + 2 * xMul == transform.position.x && position_old.y + 2 * yMul == transform.position.y; 
    }
    public override void showLegael(Transform transform)
    {
        ShowKing(1, 1);
        ShowKing(1, -1);

        ShowKing(-1, 1);
        ShowKing(-1, -1);

        ShowKing(1, 0);
        ShowKing(-1, 0);
        ShowKing(0, 1);
        ShowKing(0, -1);
    }
    private void ShowKing(int xMul, int yMul)
    {
        int startX = (int)transform.position.x / 2 + xMul;
        int startY = (int)transform.position.y + (2 * yMul);
        if (startY >= 0 && startY < 16 && startX >= 0 && startX < 8)
        {

            if (isEmpty(startX * 2, startY))
            {
                showTile(startX * 2, startY, GridThatShow);
            }
            else
            {
                if (transform.gameObject.name[1] != Pieces.PiecesBoard[startY / 2, startX][1])
                    showTile(startX * 2, startY, GridThatShowDeath);
            }
            startY += 2 * yMul;
            startX += xMul;
        }
        if (type == "klt")
        {
            GameObject rookRight = GameObject.Find("rlt 14 0");
            GameObject rookLeft = GameObject.Find("rlt 0 0");
            if (rookRight != null)
            {
                if (rookRight.GetComponent<Rook>().movementCounter == 0 && movementCounter == 0)
                {
                    if(isEmpty(10, 0) && isEmpty(12, 0))
                        showTile((int)position_old.x + 4, (int)transform.position.y, GridThatShow);
                }
            }
            if (rookLeft != null)
            {
                if (rookLeft.GetComponent<Rook>().movementCounter == 0 && movementCounter == 0)
                {
                    if (isEmpty(6, 0) && isEmpty(4, 0) && isEmpty(2, 0))
                        showTile((int)position_old.x - 6, (int)transform.position.y, GridThatShow);
                }
            }
        }
        else if (type == "kdt")
        {
            GameObject rookRight = GameObject.Find("rdt 14 14");
            GameObject rookLeft = GameObject.Find("rdt 0 14");
            if (rookRight != null)
            {
                if (rookRight.GetComponent<Rook>().movementCounter == 0 && movementCounter == 0)
                {
                    if (isEmpty(10, 14) && isEmpty(12, 14))
                        showTile((int)position_old.x + 4, (int)transform.position.y, GridThatShow);
                }
            }
            if (rookLeft != null)
            {
                if (rookLeft.GetComponent<Rook>().movementCounter == 0 && movementCounter == 0)
                {
                    if (isEmpty(6, 14) && isEmpty(4, 14) && isEmpty(2,14))
                        showTile((int)position_old.x - 6, (int)transform.position.y, GridThatShow);
                }
            }
        }
        
    }
}
