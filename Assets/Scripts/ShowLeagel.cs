using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLeagel : MonoBehaviour
{
    [SerializeField] private GameObject GridThatShow;
    [SerializeField] private GameObject GridThatShowDeath;
    int notEmptyCounter = 0;
    RaycastHit2D hitUp;
    RaycastHit2D hitDown;
    RaycastHit2D hitLeft;
    RaycastHit2D hitRight;
    public void showMoves(string name, Transform transform)
    {
        
        switch (name)
        {
            case "Rlt":
                hitUp = Physics2D.Raycast(transform.position, Vector2.up);
                hitDown = Physics2D.Raycast(transform.position, Vector2.down);
                hitLeft = Physics2D.Raycast(transform.position, Vector2.left);
                hitRight = Physics2D.Raycast(transform.position, Vector2.right);
                
                if (hitUp)
                {
                    for (int i = (int)transform.position.y/2; i < hitUp.collider.transform.position.y/2+1; i++)
                    {
                        if (Pieces.PiecesBoard[i, (int)transform.position.x / 2] == "emp")
                        {
                            showTile((int)transform.position.x, i* 2, GridThatShow);

                        }
                        else if(notEmptyCounter <= 2 && Pieces.PiecesBoard[i, (int)transform.position.x / 2].ToLower() != name.ToLower())
                        {
                            if (transform.gameObject.tag == "Peice_Black" && hitUp.collider.tag == "Peice_White" || transform.gameObject.tag == "Peice_White" && hitUp.collider.tag == "Peice_Black")
                            {
                                notEmptyCounter += 1;
                                showTile((int)transform.position.x, i * 2, GridThatShowDeath);
                            }
                            
                        }

                    }
                    notEmptyCounter = 0;
                }
                else
                {
                    for (int i = (int)transform.position.y / 2; i < 8; i++)
                    {
                        if (Pieces.PiecesBoard[i, (int)transform.position.x / 2] == "emp")
                        {

                            showTile((int)transform.position.x, i * 2, GridThatShow);
                        }

                    }
                }


                if (hitDown)
                {
                    for (int i = (int)transform.position.y / 2; i > hitDown.collider.transform.position.y / 2 - 1; i--)
                    {
                        if (Pieces.PiecesBoard[i, (int)transform.position.x / 2] == "emp")
                        {

                            showTile((int)transform.position.x, i * 2, GridThatShow);
                        }
                        else if (notEmptyCounter == 0 && Pieces.PiecesBoard[i, (int)transform.position.x / 2].ToLower() != name.ToLower())
                        {
                            
                            if (transform.gameObject.tag == "Peice_Black" && hitDown.collider.tag == "Peice_White" || transform.gameObject.tag == "Peice_White" && hitDown.collider.tag == "Peice_Black")
                            {
                                
                                notEmptyCounter += 1;
                                showTile((int)transform.position.x, i * 2, GridThatShowDeath);
                            }

                        }

                    }
                    notEmptyCounter = 0;

                }
                else
                {
                    for (int i = (int)transform.position.y / 2; i >= 0; i--)
                    {
                        if (Pieces.PiecesBoard[i, (int)transform.position.x / 2] == "emp")
                        {

                            showTile((int)transform.position.x, i * 2, GridThatShow);
                        }

                    }
                }

                if (hitLeft)
                {
                    for (int i = (int)transform.position.x / 2; i > hitLeft.collider.transform.position.x / 2 - 1; i--)
                    {
                        if (Pieces.PiecesBoard[(int)transform.position.y / 2, i] == "emp")
                        {
                            showTile(i * 2, (int)transform.position.y, GridThatShow);
                        }
                        else if (notEmptyCounter == 0 && Pieces.PiecesBoard[(int)transform.position.y / 2, i].ToLower() != name.ToLower())
                        {
                            if (transform.gameObject.tag == "Peice_Black" && hitLeft.collider.tag == "Peice_White" || transform.gameObject.tag == "Peice_White" && hitLeft.collider.tag == "Peice_Black")
                            {
                                notEmptyCounter += 1;
                                showTile(i * 2, (int)transform.position.y, GridThatShowDeath);
                            }

                        }

                    }
                    notEmptyCounter = 0;

                }
                else
                {
                    for (int i = (int)transform.position.x / 2; i >= 0; i--)
                    {
                        if (Pieces.PiecesBoard[(int)transform.position.y / 2, i] == "emp")
                        {
                            showTile(i * 2, (int)transform.position.y, GridThatShow);
                        }

                    }
                }

                if (hitRight)
                {
                    for (int i = (int)transform.position.x / 2; i < hitRight.collider.transform.position.x/2+1; i++)
                    {
                        if (Pieces.PiecesBoard[(int)transform.position.y / 2, i] == "emp")
                        {
                            showTile(i * 2, (int)transform.position.y, GridThatShow);
                        }
                        else if (notEmptyCounter == 0 && Pieces.PiecesBoard[(int)transform.position.y / 2, i].ToLower() != name.ToLower())
                        {
                            if (transform.gameObject.tag == "Peice_Black" && hitRight.collider.tag == "Peice_White" || transform.gameObject.tag == "Peice_White" && hitRight.collider.tag == "Peice_Black")
                            {
                                notEmptyCounter += 1;
                                showTile(i * 2, (int)transform.position.y, GridThatShowDeath);
                            }

                        }

                    }
                    notEmptyCounter = 0;

                }
                else
                {
                    for (int i = (int)transform.position.x / 2; i < 8; i++)
                    {
                        if (Pieces.PiecesBoard[(int)transform.position.y / 2, i] == "emp")
                        {
                            showTile(i * 2, (int)transform.position.y, GridThatShow);
                        }

                    }
                }

                break;
            case "Rdt":
                hitUp = Physics2D.Raycast(transform.position, Vector2.up);
                hitDown = Physics2D.Raycast(transform.position, Vector2.down);
                hitLeft = Physics2D.Raycast(transform.position, Vector2.left);
                hitRight = Physics2D.Raycast(transform.position, Vector2.right);

                if (hitUp)
                {
                    for (int i = (int)transform.position.y / 2; i < hitUp.collider.transform.position.y / 2 + 1; i++)
                    {
                        if (Pieces.PiecesBoard[i, (int)transform.position.x / 2] == "emp")
                        {
                            showTile((int)transform.position.x, i * 2, GridThatShow);

                        }
                        else if (notEmptyCounter == 0 && Pieces.PiecesBoard[i, (int)transform.position.x / 2].ToLower() != name.ToLower())
                        {
                            if (transform.gameObject.tag != hitUp.collider.tag)
                            {
                                notEmptyCounter += 1;
                                showTile((int)transform.position.x, i * 2, GridThatShowDeath);
                            }

                        }

                    }
                    notEmptyCounter = 0;
                }
                else
                {
                    for (int i = (int)transform.position.y / 2; i < 8; i++)
                    {
                        if (Pieces.PiecesBoard[i, (int)transform.position.x / 2] == "emp")
                        {

                            showTile((int)transform.position.x, i * 2, GridThatShow);
                        }

                    }
                }


                if (hitDown)
                {
                    for (int i = (int)transform.position.y / 2; i > hitDown.collider.transform.position.y / 2 - 1; i--)
                    {
                        if (Pieces.PiecesBoard[i, (int)transform.position.x / 2] == "emp")
                        {

                            showTile((int)transform.position.x, i * 2, GridThatShow);
                        }
                        else if (notEmptyCounter == 0 && Pieces.PiecesBoard[i, (int)transform.position.x / 2].ToLower() != name.ToLower())
                        {

                            if (transform.gameObject.tag != hitDown.collider.tag)
                            {

                                notEmptyCounter += 1;
                                showTile((int)transform.position.x, i * 2, GridThatShowDeath);
                            }

                        }

                    }
                    notEmptyCounter = 0;

                }
                else
                {
                    for (int i = (int)transform.position.y / 2; i >= 0; i--)
                    {
                        if (Pieces.PiecesBoard[i, (int)transform.position.x / 2] == "emp")
                        {

                            showTile((int)transform.position.x, i * 2, GridThatShow);
                        }

                    }
                }

                if (hitLeft)
                {
                    for (int i = (int)transform.position.x / 2; i > hitLeft.collider.transform.position.x / 2 - 1; i--)
                    {
                        if (Pieces.PiecesBoard[(int)transform.position.y / 2, i] == "emp")
                        {
                            showTile(i * 2, (int)transform.position.y, GridThatShow);
                        }
                        else if (notEmptyCounter == 0 && Pieces.PiecesBoard[(int)transform.position.y / 2, i].ToLower() != name.ToLower())
                        {
                            if (transform.gameObject.tag != hitLeft.collider.tag)
                            {
                                notEmptyCounter += 1;
                                showTile(i * 2, (int)transform.position.y, GridThatShowDeath);
                            }

                        }

                    }
                    notEmptyCounter = 0;

                }
                else
                {
                    for (int i = (int)transform.position.x / 2; i >= 0; i--)
                    {
                        if (Pieces.PiecesBoard[(int)transform.position.y / 2, i] == "emp")
                        {
                            showTile(i * 2, (int)transform.position.y, GridThatShow);
                        }

                    }
                }

                if (hitRight)
                {
                    for (int i = (int)transform.position.x / 2; i < hitRight.collider.transform.position.x / 2 + 1; i++)
                    {
                        if (Pieces.PiecesBoard[(int)transform.position.y / 2, i] == "emp")
                        {
                            showTile(i * 2, (int)transform.position.y, GridThatShow);
                        }
                        else if (notEmptyCounter == 0 && Pieces.PiecesBoard[(int)transform.position.y / 2, i].ToLower() != name.ToLower())
                        {
                            if (transform.gameObject.tag != hitRight.collider.tag)
                            {
                                notEmptyCounter += 1;
                                showTile(i * 2, (int)transform.position.y, GridThatShowDeath);
                            }

                        }

                    }
                    notEmptyCounter = 0;

                }
                else
                {
                    for (int i = (int)transform.position.x / 2; i < 8; i++)
                    {
                        if (Pieces.PiecesBoard[(int)transform.position.y / 2, i] == "emp")
                        {
                            showTile(i * 2, (int)transform.position.y, GridThatShow);
                        }

                    }
                }

                break;
            case "Nlt":
                if(!isOutOfBound((int)transform.position.x - 4, (int)transform.position.y + 2))
                {
                    if (Pieces.PiecesBoard[(int)(transform.position.y + 2)/2, (int)(transform.position.x - 4)/2] != "emp")
                    {
                        if(transform.gameObject.name[1] != Pieces.PiecesBoard[(int)(transform.position.y + 2) / 2, (int)(transform.position.x - 4) / 2][1])
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

                

                break;
            case "Ndt":
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

                break;
            case "Blt":
                
                break;
            case "Bdt":

                break;
            case "Qlt":

                break;
            case "Qdt":

                break;
            case "Klt":
                break;
            case "Kdt":

                break;
            case "Plt":

                break;
            case "Pdt":

                break;
        }
    }
    public void showTile(int x, int y, GameObject showing)
    {
        var spawnedRlt = Instantiate(showing, new Vector3(x, y), Quaternion.identity);
        spawnedRlt.name = $"GridThatShow {x} {y}";
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
