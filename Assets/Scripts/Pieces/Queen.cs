using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : PieceClass
{
    int f;
    
    public override void move()
    {
        if (!(Mathf.Abs(position_old.x - transform.position.x) == Mathf.Abs(position_old.y - transform.position.y)) && (position_old.x > transform.position.x || position_old.x < transform.position.x) && (position_old.y > transform.position.y || position_old.y < transform.position.y))
        {
            transform.position = position_old;
            illegal = true;
        }
        else
        {
        }
        if ((position_old.x > transform.position.x || position_old.x < transform.position.x) && (position_old.y < transform.position.y || position_old.y > transform.position.y))
        {
            if (position_old.x > transform.position.x)
            {
                if (position_old.y > transform.position.y)
                {
                    f = (int)(position_old.y / 2);
                    for (int i = (int)(position_old.x / 2) - 1; i > (int)(transform.position.x / 2); i -= 1)
                    {
                        f -= 1;
                        if (Pieces.PiecesBoard[f, i] != "emp")
                        {

                            transform.position = position_old;
                            illegal = true;
                            Debug.Log("1" + Pieces.PiecesBoard[f, i]);
                        }
                    }

                }
                else if (position_old.y < transform.position.y)
                {
                    f = (int)(position_old.y / 2);
                    for (int i = (int)(position_old.x / 2) - 1; i > (int)(transform.position.x / 2); i -= 1)
                    {
                        f += 1;
                        if (Pieces.PiecesBoard[f, i] != "emp")
                        {

                            transform.position = position_old;
                            illegal = true;
                            Debug.Log("2" + Pieces.PiecesBoard[f, i]);
                        }
                    }

                }
            }
            else if (position_old.x < transform.position.x)
            {
                if (position_old.y > transform.position.y)
                {
                    f = (int)(position_old.y / 2);
                    for (int i = (int)(position_old.x / 2) + 1; i < (int)(transform.position.x / 2); i += 1)
                    {
                        f -= 1;
                        if (Pieces.PiecesBoard[f, i] != "emp")
                        {

                            transform.position = position_old;
                            illegal = true;
                            Debug.Log("3" + Pieces.PiecesBoard[f, i]);
                        }
                    }

                }
                else if (position_old.y < transform.position.y)
                {
                    f = (int)(position_old.y / 2);
                    for (int i = (int)(position_old.x / 2) + 1; i < (int)(transform.position.x / 2); i += 1)
                    {
                        f += 1;
                        if (Pieces.PiecesBoard[f, i] != "emp")
                        {

                            transform.position = position_old;
                            illegal = true;
                            Debug.Log("4" + Pieces.PiecesBoard[f, i]);
                        }
                    }


                }

            }
        }
        else
        {
            if (position_old.x < transform.position.x)
            {
                //right
                for (int i = (int)(position_old.x / 2) + 1; i < (int)(transform.position.x / 2); i += 1)
                {
                    if (Pieces.PiecesBoard[(int)position_old.y / 2, i] != "emp")
                    {

                        transform.position = position_old;
                        illegal = true;
                        Debug.Log("5" + Pieces.PiecesBoard[(int)position_old.y / 2, i]);
                    }
                }
            }
            else if (position_old.x > transform.position.x)
            {


                //left
                for (int i = (int)(position_old.x / 2) - 1; i > (int)(transform.position.x / 2); i -= 1)
                {
                    if (Pieces.PiecesBoard[(int)position_old.y / 2, i] != "emp")
                    {

                        transform.position = position_old;
                        illegal = true;
                        Debug.Log("6" + Pieces.PiecesBoard[(int)position_old.y / 2, i]);
                    }
                }
            }


            if (position_old.y > transform.position.y)
            {
                //down
                for (int i = (int)(position_old.y / 2) - 1; i > (int)(transform.position.y / 2); i -= 1)
                {
                    if (Pieces.PiecesBoard[i, (int)position_old.x / 2] != "emp")
                    {

                        transform.position = position_old;
                        illegal = true;
                        Debug.Log("7" + Pieces.PiecesBoard[i, (int)position_old.x / 2]);
                    }
                }
            }
            else if (position_old.y < transform.position.y)
            {
                //up
                for (int i = (int)(position_old.y / 2) + 1; i < (int)(transform.position.y / 2); i += 1)
                {
                    if (Pieces.PiecesBoard[i, (int)position_old.x / 2] != "emp")
                    {

                        transform.position = position_old;
                        illegal = true;
                        Debug.Log("8" + Pieces.PiecesBoard[i, (int)position_old.x / 2]);
                    }
                }
            }
        }

    }

    public override void showLegael(Transform transform)
    {
        ShowMovementBRQ(1, 1, transform);
        ShowMovementBRQ(1, -1, transform);

        ShowMovementBRQ(-1, 1, transform);
        ShowMovementBRQ(-1, -1, transform);


        ShowMovementBRQ(1, 0, transform);
        ShowMovementBRQ(-1, 0, transform);

        ShowMovementBRQ(0, 1, transform);
        ShowMovementBRQ(0, -1, transform);
    }
}
