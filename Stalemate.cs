using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalemate : MonoBehaviour
{
    public bool isStalemate;
    public string[,] piecesBoard; 
    public int moveCounter; 
    public char toAttack; 

    public GameObject game;

    public int poseX;
    public int poseY;


        bool case1, case2, case3, case4, case5, case6, case7, case8;

    public checkMate checkForCheckCode;
    
    public async void Start()
    {
        game = GameObject.Find("Game");
        checkForCheckCode = (checkMate)game.GetComponent(typeof(checkMate));
    }

    public checkForCheck checkForcheckCode; 
    public bool isStalematedForKing(string[,] piecesBoard, char toAttack)
    {
        this.piecesBoard = piecesBoard; 
        this.toAttack = toAttack;
        
        for(int i = 0; i < piecesBoard.GetLength(0); i++)
        {
            for(int j = 0; j < piecesBoard.GetLength(1); i++)
            {
                if(piecesBoard[j,i][1] == toAttack)
                {
                    case1 = false;
                    case2 = false;
                    case3 = false;
                    case4 = false;
                    case5 = false;
                    case6 = false;
                    case7 = false;
                    case8 = false;  
                    switch(piecesBoard[i,j][0])
                     {
                        case 'k':
                            case1 = checkForCheckCode.checkKingCheck(0, 1, new Vector2(j, i));
                            case2 = checkForCheckCode.checkKingCheck(0, 1, new Vector2(j, i));
                            case3 = checkForCheckCode.checkKingCheck(0, 1, new Vector2(j, i));
                            case4 = checkForCheckCode.checkKingCheck(0, 1, new Vector2(j, i));
                            case5 = checkForCheckCode.checkKingCheck(0, 1, new Vector2(j, i));
                            case6 = checkForCheckCode.checkKingCheck(0, 1, new Vector2(j, i));
                            case7 = checkForCheckCode.checkKingCheck(0, 1, new Vector2(j, i));
                            case8 = checkForCheckCode.checkKingCheck(0, 1, new Vector2(j, i));
                            if (case1 && case2 && case3 && case4 && case5 && case6 && case7 && case8)
                            {
                                return true; 
                            }
                            else
                            {
                                return false;
                            }


                    }

                }
            }
        }

        return false;
        

    }

    public bool isStalematedForPieces(string[,] piecesBoard, char toAttack)
    {
        // Knight 
        if (!PieceClass.isOutOfBound((int)transform.position.x - 4, (int)transform.position.y + 2))
        {
            if (Pieces.PiecesBoard[(int)(transform.position.y + 2) / 2, (int)(transform.position.x - 4) / 2] != "emp")
            {
                if (transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(transform.position.y + 2) / 2, (int)(transform.position.x - 4) / 2][1])
                    moveCounter++;
            }
            else
            {
                moveCounter++;
            }

        }
        if (!isOutOfBound((int)transform.position.x - 4, (int)transform.position.y - 2))
        {
            if (Pieces.PiecesBoard[(int)(transform.position.y - 2) / 2, (int)(transform.position.x - 4) / 2] != "emp")
            {
                if (transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(transform.position.y - 2) / 2, (int)(transform.position.x - 4) / 2][1])
                    showTile((int)transform.position.x - 4, (int)transform.position.y - 2, GridThatShowDeath);
            }
            else
            {
                showTile((int)transform.position.x - 4, (int)transform.position.y - 2, GridThatShow);
            }

        }
        if (!isOutOfBound((int)transform.position.x + 4, (int)transform.position.y - 2))
        {
            if (Pieces.PiecesBoard[(int)(transform.position.y - 2) / 2, (int)(transform.position.x + 4) / 2] != "emp")
            {
                if (transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(transform.position.y - 2) / 2, (int)(transform.position.x + 4) / 2][1])
                    showTile((int)transform.position.x + 4, (int)transform.position.y - 2, GridThatShowDeath);
            }
            else
            {
                showTile((int)transform.position.x + 4, (int)transform.position.y - 2, GridThatShow);
            }

        }
        if (!isOutOfBound((int)transform.position.x + 4, (int)transform.position.y + 2))
        {
            if (Pieces.PiecesBoard[(int)(transform.position.y + 2) / 2, (int)(transform.position.x + 4) / 2] != "emp")
            {
                if (transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(transform.position.y + 2) / 2, (int)(transform.position.x + 4) / 2][1])
                    showTile((int)transform.position.x + 4, (int)transform.position.y + 2, GridThatShowDeath);
            }
            else
            {
                showTile((int)transform.position.x + 4, (int)transform.position.y + 2, GridThatShow);
            }

        }


        if (!isOutOfBound((int)transform.position.x - 2, (int)transform.position.y + 4))
        {
            if (Pieces.PiecesBoard[(int)(transform.position.y + 4) / 2, (int)(transform.position.x - 2) / 2] != "emp")
            {
                if (transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(transform.position.y + 4) / 2, (int)(transform.position.x - 2) / 2][1])
                    showTile((int)transform.position.x - 2, (int)transform.position.y + 4, GridThatShowDeath);
            }
            else
            {
                showTile((int)transform.position.x - 2, (int)transform.position.y + 4, GridThatShow);
            }

        }
        if (!isOutOfBound((int)transform.position.x - 2, (int)transform.position.y - 4))
        {
            if (Pieces.PiecesBoard[(int)(transform.position.y - 4) / 2, (int)(transform.position.x - 2) / 2] != "emp")
            {
                if (transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(transform.position.y - 4) / 2, (int)(transform.position.x - 2) / 2][1])
                    showTile((int)transform.position.x - 2, (int)transform.position.y - 4, GridThatShowDeath);
            }
            else
            {
                showTile((int)transform.position.x - 2, (int)transform.position.y - 4, GridThatShow);
            }

        }
        if (!isOutOfBound((int)transform.position.x + 2, (int)transform.position.y - 4))
        {
            if (Pieces.PiecesBoard[(int)(transform.position.y - 4) / 2, (int)(transform.position.x + 2) / 2] != "emp")
            {
                if (transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(transform.position.y - 4) / 2, (int)(transform.position.x + 2) / 2][1])
                    showTile((int)transform.position.x + 2, (int)transform.position.y - 4, GridThatShowDeath);
            }
            else
            {
                showTile((int)transform.position.x + 2, (int)transform.position.y - 4, GridThatShow);
            }

        }
        if (!isOutOfBound((int)transform.position.x + 2, (int)transform.position.y + 4))
        {
            if (Pieces.PiecesBoard[(int)(transform.position.y + 4) / 2, (int)(transform.position.x + 2) / 2] != "emp")
            {
                if (transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(transform.position.y + 4) / 2, (int)(transform.position.x + 2) / 2][1])
                    showTile((int)transform.position.x + 2, (int)transform.position.y + 4, GridThatShowDeath);
            }
            else
            {
                showTile((int)transform.position.x + 2, (int)transform.position.y + 4, GridThatShow);
            }

        }

    }




}
