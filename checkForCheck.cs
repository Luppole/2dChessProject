using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkForCheck : MonoBehaviour
{
    public GameObject inDanger;
    public GameObject[] allPlayers;
    
    bool case1, case2, case3, case4, case5, case6, case7, case8;

    int posX;
    int posY;
    public char toAttack;
    public string [,] piecesBoard;
    public static bool isDebug = false;
    public bool checkCheck(char toAttacks, string[,] piecesBoards)
    {
        toAttack = toAttacks;
        piecesBoard = piecesBoards;
        
        case1 = false;
        case2 = false;
        case3 = false;
        case4 = false;
        case5 = false;
        case6 = false;
        case7 = false;
        case8 = false;
        for (int i = 0; i < piecesBoard.GetLength(0); i++)
        {
            for (int j = 0; j < piecesBoard.GetLength(1); j++)
            {
                
                if (piecesBoard[i,j][0] != 'e' && piecesBoard[i,j][1] != toAttack)
                {
                    switch(piecesBoard[i,j][0]){
                        case 'r':
                            case1 = BRQKing(1, 0,  new Vector2(j, i), toAttack);
                            case2 = BRQKing(-1, 0, new Vector2(j, i), toAttack);
                            case3 = BRQKing(0, 1, new Vector2(j, i), toAttack);
                            case4 = BRQKing(0, -1, new Vector2(j, i), toAttack);
                            if(case1 || case2 || case3 || case4)
                            {
                                if (!isDebug)
                                {
                                    Debug.Log("rook check");
                                    isDebug=true;
                                }
                                
                                return true;
                            }
                            break;
                        case 'b':
                            case1 = BRQKing(1, 1, new Vector2(j, i), toAttack);
                            case2 = BRQKing(-1, 1, new Vector2(j, i), toAttack);
                            case3 = BRQKing(-1, -1, new Vector2(j, i), toAttack);
                            case4 = BRQKing(1, -1, new Vector2(j, i), toAttack);
                            if (case1 || case2 || case3 || case4)
                            {
                                if (!isDebug)
                                {
                                    Debug.Log("bishop check");
                                    isDebug=true;
                                }
                                
                                return true;
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
                            if (case1 || case2 || case3 || case4 || case5 || case6 || case7 || case8)
                            {
                                if (!isDebug)
                                {
                                    Debug.Log("queen check");
                                    isDebug=true;
                                }
                                
                                return true;
                            }
                            break;
                        case 'p':
                            if(toAttack == 'l')
                            {
                            posY = (int) i*2;

                            posX = (int) j*2;
                            if (posY != 0)
                            {
                                
                                if (posX != 0)
                                    if (!isEmpty(posX - 2, posY - 2))
                                        if (transform.gameObject.name[1] != piecesBoard[(posY - 2) / 2, (posX - 2) / 2][1])
                                            if (piecesBoard[(posY - 2) / 2, (posX - 2) / 2][0] == 'k' && piecesBoard[(posY - 2) / 2, (posX - 2) / 2][1] == toAttack)
                                                case1 = true;
                                if (posX != 14)
                                    if (!isEmpty(posX + 2, posY - 2))
                                        if (transform.gameObject.name[1] != piecesBoard[(posY - 2) / 2, (posX + 2) / 2][1])
                                            if (piecesBoard[(posY - 2) / 2, (posX + 2) / 2][0] == 'k' && piecesBoard[(posY - 2) / 2, (posX + 2) / 2][1] == toAttack)
                                                case2 = true;
                                
                            }
                            if(case1 || case2)
                            {
                                if (!isDebug)
                                {
                                    Debug.Log("pawn check black");
                                    isDebug=true;
                                }
                                
                                return true;
                            }
                        }
                        else if (toAttack == 'd')
                        {
                            posY = (int) i*2;
                            posX = (int) j*2;
                            if (posY != 14)
                            {

                                if (posX != 0)
                                    if (!isEmpty(posX - 2, posY + 2))
                                        if (transform.gameObject.name[1] != piecesBoard[(posY + 2) / 2, (posX - 2) / 2][1])
                                            if (piecesBoard[(posY + 2) / 2, (posX - 2) / 2][0] == 'k' && piecesBoard[(posY + 2) / 2, (posX - 2) / 2][1] == toAttack)
                                                case1 = true;
                                if (posX != 14)
                                    if (!isEmpty(posX + 2, posY + 2))
                                        if (transform.gameObject.name[1] != piecesBoard[(posY + 2) / 2, (posX + 2) / 2][1])
                                            if (piecesBoard[(posY + 2) / 2, (posX + 2) / 2][0] == 'k' && piecesBoard[(posY + 2) / 2, (posX + 2) / 2][1] == toAttack)
                                                case2 = true;

                            }
                            if (case1 || case2)
                            {
                                if (!isDebug)
                                {
                                    Debug.Log("pawn check white");
                                    isDebug=true;
                                }
                                
                                return true;
                            }
                        }
                        break;
                    case 'n':
                        posY = (int) i*2;
                        posX = (int) j*2;
                        if (!isOutOfBound(posX - 4, posY + 2))
                        {
                            if (piecesBoard[(posY + 2) / 2, (posX - 4) / 2] != "emp")
                            {
                                if (piecesBoard[(posY + 2) / 2, (posX - 4) / 2][0] == 'k' && piecesBoard[(posY + 2) / 2, (posX - 4) / 2][1] == toAttack)
                                    case1 = true;

                            }
                        }
                        if (!isOutOfBound(posX - 4, posY - 2))
                        {
                            if (piecesBoard[(posY - 2) / 2, (posX - 4) / 2] != "emp")
                            {
                                if (piecesBoard[(posY - 2) / 2, (posX - 4) / 2][0] == 'k' && piecesBoard[(posY - 2) / 2, (posX - 4) / 2][1] == toAttack)
                                    case2 = true;
                            }

                        }
                        if (!isOutOfBound(posX + 4, posY - 2))
                        {
                            if (piecesBoard[(posY - 2) / 2, (posX + 4) / 2] != "emp")
                            {
                                if (piecesBoard[(posY - 2) / 2, (posX + 4) / 2][0] == 'k' && piecesBoard[(posY - 2) / 2, (posX + 4) / 2][1] == toAttack)
                                    case3 = true;
                            }

                        }
                        if (!isOutOfBound(posX + 4, posY + 2))
                        {
                            if (piecesBoard[(posY + 2) / 2, (posX + 4) / 2] != "emp")
                            {
                                if (piecesBoard[(posY + 2) / 2, (posX + 4) / 2][0] == 'k' && piecesBoard[(posY + 2) / 2, (posX + 4) / 2][1] == toAttack)
                                    case4 = true;
                            }

                        }


                        if (!isOutOfBound(posX - 2, posY + 4))
                        {
                            if (piecesBoard[(posY + 4) / 2, (posX - 2) / 2] != "emp")
                            {
                                if (piecesBoard[(posY + 4) / 2, (posX - 2) / 2][0] == 'k' && piecesBoard[(posY + 4) / 2, (posX - 2) / 2][1] == toAttack)
                                    case5 = true;
                            }

                        }
                        if (!isOutOfBound(posX - 2, posY - 4))
                        {
                            if (piecesBoard[(posY - 4) / 2, (posX - 2) / 2] != "emp")
                            {
                                if (piecesBoard[(posY - 4) / 2, (posX - 2) / 2][0] == 'k' && piecesBoard[(posY - 4) / 2, (posX - 2) / 2][1] == toAttack)
                                    case6 = true;
                            }

                        }
                        if (!isOutOfBound(posX + 2, posY - 4))
                        {
                            if (piecesBoard[(posY - 4) / 2, (posX + 2) / 2] != "emp")
                            {
                                if (piecesBoard[(posY - 4) / 2, (posX + 2) / 2][0] == 'k' && piecesBoard[(posY - 4) / 2, (posX + 2) / 2][1] == toAttack)
                                    case6 = true;
                            }

                        }
                        if (!isOutOfBound(posX + 2, posY + 4))
                        {
                            if (piecesBoard[(posY + 4) / 2, (posX + 2) / 2] != "emp")
                            {
                                if (piecesBoard[(posY + 4) / 2, (posX + 2) / 2][0] == 'k' && piecesBoard[(posY + 4) / 2, (posX + 2)/2][1] == toAttack)
                                    case7 = true;
                            }

                        }
                        if (case1 || case2 || case3 || case4 || case5 || case6 || case7 || case8)
                        {
                            if (!isDebug)
                                {
                                    Debug.Log("knight check");
                                    isDebug=true;
                                }
                            
                            return true;
                        }
                        break;
                    case 'k':

                        case1 = checkKingCheck(0, 1, new Vector2(j, i));
                        case2 = checkKingCheck(0, -1, new Vector2(j, i));
                        case3 = checkKingCheck(1, 1, new Vector2(j, i));
                        case4 = checkKingCheck(1, 0, new Vector2(j, i));
                        case5 = checkKingCheck(1, -1, new Vector2(j, i));
                        case6 = checkKingCheck(-1, 0, new Vector2(j, i));
                        case7 = checkKingCheck(-1, 1, new Vector2(j, i));
                        case8 = checkKingCheck(-1, -1, new Vector2(j, i));
                        if (case1 || case2 || case3 || case4 || case5 || case6 || case7 || case8)
                        {
                            if (!isDebug)
                            {
                                Debug.Log("king check");
                                isDebug=true;
                            }
                            
                            return true;
                        }
                        break;
                    }
                    
                    
                }

            }
        }
        
        return false;
    }
    
    public bool BRQKing(int xMul, int yMul, Vector2 loc, char toAttack)
    {
        int startX = (int)loc.x + xMul;
        int startY = (int)loc.y + (1 * yMul);

        while (startY >= 0 && startY < 8 && startX >= 0 && startX < 8)
        {

            if (!isEmpty(startX * 2, startY*2))
            {
                if ('k' == piecesBoard[startY, startX][0] && toAttack == piecesBoard[startY, startX][1])
                    return true;
                break;
            }
            startY += 1 * yMul;
            startX += xMul;
        }
        return false;
    }

    public bool checkKingCheck(int xMul, int yMul, Vector2 transform)
    {
        int startX = (int)transform.x / 2 + xMul;
        int startY = (int)transform.y + (2 * yMul);
        if (startY >= 0 && startY < 16 && startX >= 0 && startX < 8)
        {

            if (!isEmpty(startX * 2, startY))
            {
                if (piecesBoard[startY / 2, startX][0] == 'k' && piecesBoard[startY / 2, startX][1] == toAttack)
                {
                    return true;
                }
            }
            startY += 2 * yMul;
            startX += xMul;
        }
        return false;
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
        if (x > 14 || x < 0)
        {
            return true;
        }
        if (y > 14 || y < 0)
        {
            return true;
        }
        return false;
    }
}
