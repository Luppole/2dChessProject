using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : PieceClass
{
    bool case1, case2, case3, case4, case5, case6, case7, case8;
    public override void move()
    {
        case1 = (position_old.x - 4 == transform.position.x && position_old.y + 2 == transform.position.y);
        case2 = (position_old.x - 4 == transform.position.x && position_old.y - 2 == transform.position.y);
        case3 = (position_old.x + 4 == transform.position.x && position_old.y - 2 == transform.position.y);
        case4 = (position_old.x + 4 == transform.position.x && position_old.y + 2 == transform.position.y);

        case5 = (position_old.x + 2 == transform.position.x && position_old.y + 4 == transform.position.y);
        case6 = (position_old.x - 2 == transform.position.x && position_old.y + 4 == transform.position.y);
        case7 = (position_old.x - 2 == transform.position.x && position_old.y - 4 == transform.position.y);
        case8 = (position_old.x + 2 == transform.position.x && position_old.y - 4 == transform.position.y);
        if (case1 || case2 || case3 || case4 || case5 || case6 || case7 || case8)
        {

        }
        else
        {
            transform.position = position_old;
        }

    }

    public override void showLegael(Transform transform)
    {
        if (!isOutOfBound((int)transform.position.x - 4, (int)transform.position.y + 2))
        {
            if (Pieces.PiecesBoard[(int)(transform.position.y + 2) / 2, (int)(transform.position.x - 4) / 2] != "emp")
            {
                if (transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(transform.position.y + 2) / 2, (int)(transform.position.x - 4) / 2][1])
                    showTile((int)transform.position.x - 4, (int)transform.position.y + 2, GridThatShowDeath);
            }
            else
            {

                showTile((int)transform.position.x - 4, (int)transform.position.y + 2, GridThatShow);
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
