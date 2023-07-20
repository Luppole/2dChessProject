using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Bishop : PieceClass
{
    int f;
    
    
    public override void move()
    {
        if (!(Mathf.Abs(position_old.x - transform.position.x) == Mathf.Abs(position_old.y - transform.position.y)))
        {
            transform.position = position_old;
            illegal = true;
        }
        
        f = (int)(position_old.y / 2);

        if (position_old.x > transform.position.x)
        {
            if (position_old.y > transform.position.y)
            {
                f = (int)(position_old.y / 2);
                for (int i = (int)(position_old.x / 2) - 1; i > (int)(transform.position.x / 2); i -= 1)
                {
                    f -= 1;
                    if (!isEmpty(i * 2, f * 2))
                    {

                        transform.position = position_old;
                        illegal = true;
                        Debug.Log(Pieces.PiecesBoard[f, i]);
                    }
                }

            }
            else if (position_old.y < transform.position.y)
            {
                f = (int)(position_old.y / 2);
                for (int i = (int)(position_old.x / 2) - 1; i > (int)(transform.position.x / 2); i -= 1)
                {
                    f += 1;
                    if (!isEmpty(i * 2, f * 2))
                    {

                        transform.position = position_old;
                        illegal = true;
                        Debug.Log(Pieces.PiecesBoard[f, i]);
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
                    if (!isEmpty(i * 2, f * 2))
                    {

                        transform.position = position_old;
                        illegal = true;
                        Debug.Log(Pieces.PiecesBoard[f, i]);
                    }
                }

            }
            else if (position_old.y < transform.position.y)
            {
                f = (int)(position_old.y / 2);
                for (int i = (int)(position_old.x / 2) + 1; i < (int)(transform.position.x / 2); i += 1)
                {
                    f += 1;
                    if (!isEmpty(i * 2, f * 2))
                    {

                        transform.position = position_old;
                        illegal = true;
                        Debug.Log(Pieces.PiecesBoard[f, i]);
                    }
                }

            }
        }

        
    }

    public override void showLegael(Transform transform)
    {
        ShowMovementBRQ(1, 1,transform);
        ShowMovementBRQ(1, -1, transform);

        ShowMovementBRQ(-1, 1, transform);
        ShowMovementBRQ(-1, -1, transform);
    }
    

}