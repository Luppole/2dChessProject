using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;
using static UnityEngine.GraphicsBuffer;

public class checkMate : MonoBehaviour
{
    public GameObject game;
    public checkForCheck checkForCheckCode;
    public string[,] piecesBoard;
    bool case1, case2, case3, case4, case5, case6, case7, case8;
    public char toAttack;
    public bool isCheckMate;
    public string[,] temp = new string[8,8];
    int posX;
    int posY;
    void Start()
    {
        game = GameObject.Find("Game");
        checkForCheckCode = (checkForCheck)game.GetComponent(typeof(checkForCheck));
    }
    public bool checkMateFunc(char toAttacks, string[,] piecesBoards)
    {
        isCheckMate = true;
        toAttack = toAttacks;
        case1 = false;
        case2 = false;
        case3 = false;
        case4 = false;
        case5 = false;
        case6 = false;
        case7 = false;
        case8 = false;
        piecesBoard = piecesBoards;
        for (int i = 0; i < piecesBoard.GetLength(0); i++)
        {
            for (int j = 0; j < piecesBoard.GetLength(1); j++)
            {
                if (piecesBoard[i, j][0] != 'e' && piecesBoard[i, j][1] == toAttack)
                {
                    switch (piecesBoard[i, j][0])
                    {
                        case 'r':
                            case1 = BRQKing(1, 0, new Vector2(j, i), toAttack);
                            case2 = BRQKing(-1, 0, new Vector2(j, i), toAttack);
                            case3 = BRQKing(0, 1, new Vector2(j, i), toAttack);
                            case4 = BRQKing(0, -1, new Vector2(j, i), toAttack);
                            if (!case1 || !case2 || !case3 || !case4)
                            {
                                isCheckMate = false;
                            }
                            else
                            {
                                //Debug.Log("rook check" + toAttack);
                            }

                            break;
                        case 'b':
                            case1 = BRQKing(1, 1, new Vector2(j, i), toAttack);
                            case2 = BRQKing(-1, 1, new Vector2(j, i), toAttack);
                            case3 = BRQKing(-1, -1, new Vector2(j, i), toAttack);
                            case4 = BRQKing(1, -1, new Vector2(j, i), toAttack);
                            if (!case1 || !case2 || !case3 || !case4)
                            {
                                isCheckMate = false;
                            }
                            else
                            {
                                //Debug.Log("bishop check" + toAttack);
                            }

                            break;
                        case 'q':
                            case1 = BRQKing(1, 1, new Vector2(j, i), toAttack);
                            case2 = BRQKing(-1, 1, new Vector2(j, i), toAttack);
                            case3 = BRQKing(-1, -1, new Vector2(j, i), toAttack);
                            case4 = BRQKing(1, -1, new Vector2(j, i), toAttack);
                            case5 = BRQKing(1, 0, new Vector2(j, i), toAttack);
                            case6 = BRQKing(-1, 0, new Vector2(j, i), toAttack);
                            case7 = BRQKing(0, 1, new Vector2(j, i), toAttack);
                            case8 = BRQKing(0, -1, new Vector2(j, i), toAttack);
                            if (!case1 || !case2 || !case3 || !case4 || !case5 || !case6 || !case7 || !case8)
                            {
                                isCheckMate = false;
                            }
                            else
                            {
                                //Debug.Log("queen check" + toAttack);
                            }

                            break;
                        case 'p':
                            if (toAttack == 'd')
                            {
                                posY = (int)i;
                                posX = (int)j;
                                temp[(int)posY, (int)posX] = "emp";
                                for (int f = 0; f < piecesBoard.GetLength(0); f++)
                                {
                                    for (int d = 0; d < piecesBoard.GetLength(1); d++)
                                    {
                                        temp[f, d] = piecesBoard[f, d];
                                    }
                                }
                                if (posY != 0)
                                {

                                    if (isEmpty((int)(posX)*2, (int)(posY - 1)*2)){
                                        checkWithNewList(toAttack, posY, posX, -1, 0);
                                    }
                                    temp[posY, posX] = "emp";
                                    if (posX != 0)
                                        if (!isEmpty((int)(posX - 1)*2, (int)(posY - 1)*2))
                                            if (toAttack != Pieces.PiecesBoard[(int)(posY - 1) / 2, (int)(posX - 1)][1]){
                                                checkWithNewList(toAttack, posY, posX, -1, -1);
                                            }
                                    if (posX != 7)
                                        if (!isEmpty((int)(posX + 1)*2, (int)(posY - 1)*2))
                                            checkWithNewList(toAttack, posY, posX, -1, 1);
                                    if ((posY == 6) && isEmpty((int)(posX) * 2, (int)(posY - 1) * 2) && isEmpty((int)(posX) * 2, (int)(posY - 2) * 2)){
                                        checkWithNewList(toAttack, posY, posX, -2, 0);
                                    }
                                }
                            }
                            else if (toAttack == 'l')
                            {
                                posY = (int)i;
                                posX = (int)j;
                                temp[(int)posY, (int)posX] = "emp";
                                
                                if (posY != 7)
                                {

                                    if (isEmpty((int)(posX)*2, (int)(posY + 1)*2)){
                                        checkWithNewList(toAttack, posY, posX, 1, 0);
                                    }
                                    if (posX != 0)
                                        if (!isEmpty((int)(posX - 1)*2, (int)(posY + 1)*2))
                                            checkWithNewList(toAttack, posY, posX, 1, -1);
                                    temp[posY, posX] = "emp";
                                    if (posX != 7)
                                        if (!isEmpty((int)(posX + 1)*2, (int)(posY + 1)*2))
                                            if (toAttack != Pieces.PiecesBoard[(int)(posY + 1), (int)(posX + 1)][1]){
                                                checkWithNewList(toAttack, posY, posX, 1, 1);
                                            }
                                    
                                    if ((posY == 2) && isEmpty((int)(posX)*2, (int)(posY + 1)*2) && isEmpty((int)(posX) * 2, (int)(posY + 2) * 2)){
                                        checkWithNewList(toAttack, posY, posX, 2, 0);
                                    }
                                    
                                }
                            }
                            break;
                        case 'n':
                            posY = (int)i;
                            posX = (int)j;
                             
                            knightCheck(toAttack, posY, posX, 1, -2);
                            knightCheck(toAttack, posY, posX, 1, 2);
                            knightCheck(toAttack, posY, posX, -1, -2);
                            knightCheck(toAttack, posY, posX, -1, 2);
                            knightCheck(toAttack, posY, posX, 2, -1);
                            knightCheck(toAttack, posY, posX, 2, 1);
                            knightCheck(toAttack, posY, posX, -2, 1);
                            knightCheck(toAttack, posY, posX, -2, -1);
                            break;
                        case 'k':
                            posY = (int)i;
                            posX = (int)j;
                            case1 = checkKingCheck(0, 1, new Vector2(j, i));
                            case2 = checkKingCheck(0, -1, new Vector2(j, i));
                            case3 = checkKingCheck(1, 1, new Vector2(j, i));
                            case4 = checkKingCheck(1, 0, new Vector2(j, i));
                            case5 = checkKingCheck(1, -1, new Vector2(j, i));
                            case6 = checkKingCheck(-1, 0, new Vector2(j, i));
                            case7 = checkKingCheck(-1, 1, new Vector2(j, i));
                            case8 = checkKingCheck(-1, -1, new Vector2(j, i));
                            if (!case1 || !case2 || !case3 || !case4 || !case5 || !case6 || !case7 || !case8)
                            {
                                isCheckMate = false;
                            }
                            else
                            {
                                //Debug.Log("queen check" + toAttack);
                            }
                            break;
                    }

                }
            }
        }
                //checkForCheckCode.checkCheck(toAttack)
        return isCheckMate;
    }
    public bool BRQKing(int xMul, int yMul, Vector2 loc, char toAttack)
    {
        int startX = (int)loc.x + xMul;
        int startY = (int)loc.y + (1 * yMul);
        bool isMate = true;
        while (startY >= 0 && startY < 8 && startX >= 0 && startX < 8)
        {
            for (int i = 0; i < piecesBoard.GetLength(0); i++)
            {
                for (int j = 0; j < piecesBoard.GetLength(1); j++)
                {
                    temp[i, j] = piecesBoard[i, j];
                }
            }
            if (!isEmpty(startX * 2, startY * 2))
            {
                if ('k' != piecesBoard[startY, startX][0] && toAttack != piecesBoard[startY, startX][1])
                {
                    temp[(int)loc.y, (int)loc.x] = "emp";
                    if (toAttack == 'd')
                       temp[startY, startX] = "pdt";
                    if (toAttack == 'l')
                       temp[startY, startX] = "plt";
                    if (!checkForCheckCode.checkCheck(toAttack, temp))
                        isMate = false;
                }
                    
                break;
            }
            temp[(int)loc.y, (int)loc.x] = "emp";
            if(toAttack == 'd')
                temp[startY, startX] = "pdt";
            if (toAttack == 'l')
                temp[startY, startX] = "plt";
            
            if (!checkForCheckCode.checkCheck(toAttack, temp))
            {
                isMate = false;
            }
            startY += 1 * yMul;
            startX += xMul;
        }
        return isMate;
    }

    public bool checkKingCheck(int xMul, int yMul, Vector2 transform)
    {
        int startX = (int)transform.x + xMul;
        int startY = (int)transform.y + yMul;
        bool isMate = true;
        for (int i = 0; i < piecesBoard.GetLength(0); i++)
            {
                for (int j = 0; j < piecesBoard.GetLength(1); j++)
                {
                    temp[i, j] = piecesBoard[i, j];
                }
            }
        if (startY >= 0 && startY < 8 && startX >= 0 && startX < 8)
        {
            temp[(int)transform.y, (int)transform.x] = "emp";

            if (isEmpty(startX *2, startY*2))
            {
                if(toAttack == 'd'){
                    
                    temp[startY,startX] = "kdt";
                    if(!checkForCheckCode.checkCheck(toAttack, temp)){
                        isCheckMate = false;
                    }
                }else{
                    temp[startY,startX] = "klt";
                    if(!checkForCheckCode.checkCheck(toAttack, temp)){
                        isCheckMate = false;
                    } 
                    
                }
                
            }
            else
            {
                if (toAttack != Pieces.PiecesBoard[startY, startX][1]){
                    if(toAttack == 'd'){
                        temp[startY,startX] = "kdt";
                        if(!checkForCheckCode.checkCheck(toAttack, temp)){
                            isCheckMate = false;
                        }   
                    }else{
                       temp[startY,startX] = "klt";
                        if(!checkForCheckCode.checkCheck(toAttack, temp)){
                            isCheckMate = false;
                        }  
                    }
                    
                }
            }
            startY += yMul;
            startX += xMul;
        }
        return isMate;
    }
    public void checkWithNewList(char toAttack, int posY, int posX, int posYoffset, int posXoffset)
    {
        string[,] temp = new string[8, 8];
        for (int i = 0; i < piecesBoard.GetLength(0); i++)
        {
            for (int j = 0; j < piecesBoard.GetLength(1); j++)
            {
                temp[i, j] = piecesBoard[i, j];
            }
        }
        if (toAttack != Pieces.PiecesBoard[(int)(posY + posYoffset), (int)(posX + posXoffset)][1])
        {
            if (toAttack == 'd')
                temp[posY + posYoffset, posX + posXoffset] = "pdt";
            else
                temp[posY + posYoffset, posX + posXoffset] = "plt";
            if (!checkForCheckCode.checkCheck(toAttack, temp))
            {
                isCheckMate = false;
            }
            temp[posY + posYoffset, posX + posXoffset] = "emp";
        }
    }
    public void knightCheck(char toAttack, int posY, int posX, int posYoffset, int posXoffset)
    {
        if (!isOutOfBound((int)posX + posXoffset, (int)posY + posYoffset))
        {
            if (Pieces.PiecesBoard[(int)(posY + posYoffset), (int)(posX + posXoffset)] != "emp")
            {
                if (toAttack != Pieces.PiecesBoard[(int)(posY + posYoffset), (int)(posX + posXoffset)][1])
                    checkWithNewList(toAttack, posY, posX, posYoffset, posXoffset);
            }
            else
            {
                checkWithNewList(toAttack, posY, posX, posYoffset, posXoffset);
            }

        }
    }
    public bool isEmpty(float LocX, float LocY)
    {
        if (piecesBoard[(int)LocY / 2, (int)LocX / 2] == "emp")
        {
            return true;
        }
        return false;
    }
    public bool isOutOfBound(int x, int y)
    {
        if (x > 7 || x < 0)
        {
            return true;
        }
        if (y > 7 || y < 0)
        {
            return true;
        }
        return false;
    
    }
}
