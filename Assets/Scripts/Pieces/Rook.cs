using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

public class Rook : PieceClass
{
    public int notEmptyCounter = 0;
    RaycastHit2D hitUp;
    RaycastHit2D hitDown;
    RaycastHit2D hitLeft;
    RaycastHit2D hitRight;
    public override void move()
    {
        if ((position_old.x > transform.position.x || position_old.x < transform.position.x) && (position_old.y > transform.position.y || position_old.y < transform.position.y))
        {
            Debug.Log("here1");
            transform.position = position_old;
            illegal = true;
        }


        if ((position_old.x > transform.position.x || position_old.x < transform.position.x) && (position_old.y > transform.position.y || position_old.y < transform.position.y))
        {
            Debug.Log("here");
            transform.position = position_old;
            illegal = true;
        }

        if (position_old.x < transform.position.x)
        {
            //right
            for (int i = (int)(position_old.x / 2) + 1; i < (int)(transform.position.x / 2); i += 1)
            {
                if (Pieces.PiecesBoard[(int)position_old.y / 2, i] != "emp")
                {

                    transform.position = position_old;
                    illegal = true;
                    Debug.Log(Pieces.PiecesBoard[(int)position_old.y / 2, i]);
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
                    Debug.Log(Pieces.PiecesBoard[(int)position_old.y / 2, i]);
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
                    Debug.Log(Pieces.PiecesBoard[i, (int)position_old.x / 2]);
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
                    Debug.Log(Pieces.PiecesBoard[i, (int)position_old.x / 2]);
                }
            }
        }

    }

    public override void showLegael(Transform transform)
    {

        ShowMovementBRQ(1, 0, transform);
        ShowMovementBRQ(-1, 0, transform);

        ShowMovementBRQ(0, 1, transform);
        ShowMovementBRQ(0, -1, transform);

        
    }

}
