using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public abstract class PieceClass : MonoBehaviour
{
    public Vector3 dragOffset;
    [SerializeField] public static float speed = 70;

    [SerializeField] public GameObject GridThatShow;
    [SerializeField] public GameObject GridThatShowDeath;

    

    public int movementCounter = 0;
    public bool illegal = false;

    public Vector2 position_old;


    public GameObject game;
    public ShowLeagel showLeagel;
    public Pieces pieces;
    public ChoosePromotionDropdown dropdown;
    public ShowTheDead showTheDead;
    public checkForCheck checkForCheckCode;
    public ShowUI showUI;
    public checkMate checkMateCode;
    public Sound sound;
    

    public string type;

    public static bool finishMove = false;

    public static string turn = "white";
    public static int totalMoveCounter = 0;

    public static bool isDropdownActive = false;

    public static int pointsBlack = 0;
    public static int pointsWhite = 0;

    public static string checkWhiteBlack;

    private void Update()
    {
        if(finishMove)
        {
            
            if (Pieces.PiecesBoard[(int)transform.position.y / 2, (int)transform.position.x / 2] != type)
            {
                if(transform.tag == "Peice_White")
                {
                    pointsBlack += checkPoints(transform.name.ToLower());

                }
                else if(transform.tag == "Peice_Black")
                {
                    pointsWhite += checkPoints(transform.name.ToLower());
                }
                Debug.Log("eating: "+ transform.gameObject.name);
                sound.capture();
                Destroy(transform.gameObject);
            }
        }
    }

    void OnMouseDown()
    {
        
        dragOffset = transform.position - GetMousePos();
        position_old = transform.position;
        finishMove = false;
        if (type[1] == 'l' && turn == "white" && !isDropdownActive)
        {
            showLegael(transform);
        }
        if (type[1] == 'd' && turn == "black" && !isDropdownActive)
        {
            showLegael(transform);
        }


        //showLegael(transform);

    }

    void OnMouseDrag()
    {
        if (type[1] == 'l' && turn == "white" && !isDropdownActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + dragOffset, speed * Time.deltaTime);

        }
        if (type[1] == 'd' && turn == "black" && !isDropdownActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + dragOffset, speed * Time.deltaTime);
        }
        //transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + dragOffset, speed * Time.deltaTime);


    }
    
    private void OnMouseUp()
    {
        transform.position = new Vector2(Mathf.RoundToInt(transform.position.x / 2) * 2, Mathf.RoundToInt(transform.position.y / 2) * 2);
        illegal = outOfBounds();
        GameObject[] tilesShows = GameObject.FindGameObjectsWithTag("ShowTile");
        foreach (GameObject tilesShow in tilesShows)
            Destroy(tilesShow);
        move();
        cantEatking();
        cantEatSameColor(type);
        preventCheckMoving();        
        updateArr(type);
        
        if (!illegal && transform.position.x != position_old.x || transform.position.y != position_old.y)
        {
            sound.move();
            movementCounter++;
            totalMoveCounter++;
            finishMove = true;
            transform.name = type + " " + transform.position.x + " " + transform.position.y;
            if(turn == "white")
            {
                turn = "black";
            }
            else
            {
                turn = "white";
            }
            checkAndMateCheck(Pieces.PiecesBoard);
            checkForCheck.isDebug = false;
        //     showUI.showCheck(checkForCheckCode.checkCheck('l', Pieces.PiecesBoard), 'l');
        //     showUI.showCheck(checkForCheckCode.checkCheck('d', Pieces.PiecesBoard), 'd');
        //     if(checkForCheckCode.checkCheck('d', Pieces.PiecesBoard) || checkForCheckCode.checkCheck('l', Pieces.PiecesBoard))
        //     {
        //         sound.check();
        //     }
        //     if(checkForCheckCode.checkCheck('d', Pieces.PiecesBoard)|| checkForCheckCode.checkCheck('l', Pieces.PiecesBoard))
        //     {
        //         if (checkMateCode.checkMateFunc('d', Pieces.PiecesBoard))
        //         {
        //             showUI.showWin('l');
        //             sound.gameoverCheckmate();
        //         }
        //         else if (checkMateCode.checkMateFunc('l', Pieces.PiecesBoard))
        //         {
        //             showUI.showWin('d');
        //             sound.gameoverCheckmate();
        //         }
        //     }
            
        }
       
        

    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.x = Mathf.RoundToInt(mousePos.x / 2) * 2;
        mousePos.y = Mathf.RoundToInt(mousePos.y / 2) * 2;
        return mousePos;
    }


    private async void Start()
    {
        
        GridThatShow = (GameObject)Resources.Load("NormalShowMove", typeof(GameObject));
        GridThatShowDeath = (GameObject)Resources.Load("EatShow", typeof(GameObject));
        game = GameObject.Find("Game");
        showLeagel = (ShowLeagel)game.GetComponent(typeof(ShowLeagel));
        showTheDead = (ShowTheDead)game.GetComponent(typeof(ShowTheDead));

        pieces = (Pieces)game.GetComponent(typeof(Pieces));
        dropdown = (ChoosePromotionDropdown)game.GetComponent(typeof(ChoosePromotionDropdown));

        showUI = (ShowUI)game.GetComponent(typeof(ShowUI));

        checkForCheckCode = (checkForCheck)game.GetComponent(typeof(checkForCheck));

        checkMateCode = (checkMate)game.GetComponent(typeof(checkMate));

        sound = (Sound)game.GetComponent(typeof(Sound));
        sound.start();
    }

    public bool outOfBounds()
    {
        if (transform.position.x > 14 || transform.position.x < 0)
        {
            transform.position = position_old;
            return true;
        }
        if (transform.position.y > 14 || transform.position.y < 0)
        {
            transform.position = position_old;
            return true;
        }
        return false;

    }

    public bool isEmpty(float LocX, float LocY)
    {
        if (Pieces.PiecesBoard[(int)LocY / 2, (int)LocX / 2] == "emp")
        {
            return true;
        }
        return false;
    }

    
    public void showTile(int x, int y, GameObject showing)
    {
        var spawnedRlt = Instantiate(showing, new Vector3(x, y), Quaternion.identity);
        spawnedRlt.name = $"GridThatShow {x} {y}";
    }
    public static bool isOutOfBound(int x, int y)
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
    
    public virtual void ShowMovementBRQ(int xMul, int yMul ,Transform transform)
    {
        int startX = (int)transform.position.x / 2 + xMul;
        int startY = (int)transform.position.y + (2 * yMul);

        while (startY >= 0 && startY < 16 && startX >= 0 && startX < 8)
        {

            if (isEmpty(startX * 2, startY))
            {
                showTile(startX * 2, startY, GridThatShow);
            }
            else
            {
                if (transform.gameObject.name[1] != Pieces.PiecesBoard[startY / 2, startX][1])
                    showTile(startX * 2, startY, GridThatShowDeath);
                break;
            }
            startY += 2 * yMul;
            startX += xMul;
        }
    }
    
    private void cantEatking()
    {
        if(Pieces.PiecesBoard[(int)transform.position.y / 2, (int)transform.position.x / 2][0] == 'k')
        {
            illegal = true;
            transform.position = position_old;
        }
    }
    public int checkPoints(string name)
    {
        switch (name[0])
        {
            case 'p':
                showTheDead.updateTheDead(1, type);
                return 1;
            case 'n':
                showTheDead.updateTheDead(2, type);
                return 3;
            case 'b':
                showTheDead.updateTheDead(3, type);
                return 3;
            case 'r':
                showTheDead.updateTheDead(4, type);
                return 5;
            case 'q':
                showTheDead.updateTheDead(5, type);
                return 9;

        }
        return 0;
    }
    public void preventCheckMoving()
    {
        string[,] temp = new string[8, 8];
        for (int i = 0; i < Pieces.PiecesBoard.GetLength(0); i++)
        {
            for (int j = 0; j < Pieces.PiecesBoard.GetLength(1); j++)
            {
                temp[i, j] = Pieces.PiecesBoard[i, j];
            }
        }

        if (type == "klt" && (transform.position.x != position_old.x || transform.position.y != position_old.y))
        {
            temp[(int)position_old.y / 2, (int)position_old.x / 2] = "emp";
            temp[(int)transform.position.y / 2, (int)transform.position.x / 2] = "klt";
            if (checkForCheckCode.checkCheck('l', temp))
            {
                illegal = true;
                transform.position = position_old;
            }

        }
        else if (type == "kdt" && (transform.position.x != position_old.x || transform.position.y != position_old.y))
        {
            temp[(int)position_old.y / 2, (int)position_old.x / 2] = "emp";
            temp[(int)transform.position.y / 2, (int)transform.position.x / 2] = "kdt";
            if (checkForCheckCode.checkCheck('d', temp))
            {
                illegal = true;
                transform.position = position_old;
            }

        }
        else if (type[1] == 'd' && (transform.position.x != position_old.x || transform.position.y != position_old.y))
        {
            temp[(int)position_old.y / 2, (int)position_old.x / 2] = "emp";
            temp[(int)transform.position.y / 2, (int)transform.position.x / 2] = type;
            if (checkForCheckCode.checkCheck('d', temp))
            {
                illegal = true;
                transform.position = position_old;
                sound.cantMoveInCheck();
                for (int i = 0; i < Pieces.PiecesBoard.GetLength(0); i++)
                {
                    for (int j = 0; j < Pieces.PiecesBoard.GetLength(1); j++)
                    {
                        if(Pieces.PiecesBoard[i, j] == "kdt")
                        {
                            
                            StartCoroutine(kingsShowThatCheck(j*2, i*2));
                        }
                    }
                }
            }

        }
        else if (type[1] == 'l' && (transform.position.x != position_old.x || transform.position.y != position_old.y))
        {
            temp[(int)position_old.y / 2, (int)position_old.x / 2] = "emp";
            temp[(int)transform.position.y / 2, (int)transform.position.x / 2] = type;
            if (checkForCheckCode.checkCheck('l', temp))
            {
                illegal = true;
                transform.position = position_old;
                sound.cantMoveInCheck();
                for (int i = 0; i < Pieces.PiecesBoard.GetLength(0); i++)
                {
                    for (int j = 0; j < Pieces.PiecesBoard.GetLength(1); j++)
                    {
                        if (Pieces.PiecesBoard[i, j] == "klt")
                        {

                            StartCoroutine(kingsShowThatCheck(j * 2, i * 2));
                        }
                    }
                }
            }

        }
    }
    IEnumerator kingsShowThatCheck(int x, int y)
    {
        GameObject[] tilesShows;
        showTile(x, y, GridThatShowDeath);

        yield return new WaitForSeconds(0.3F);

        tilesShows = GameObject.FindGameObjectsWithTag("ShowTile");
        foreach (GameObject tilesShow in tilesShows)
            Destroy(tilesShow);

        yield return new WaitForSeconds(0.3F);

        showTile(x, y, GridThatShowDeath);

        yield return new WaitForSeconds(0.3F);

        tilesShows = GameObject.FindGameObjectsWithTag("ShowTile");
        foreach (GameObject tilesShow in tilesShows)
            Destroy(tilesShow);

        yield return new WaitForSeconds(0.3F);

        showTile(x, y, GridThatShowDeath);

        yield return new WaitForSeconds(0.3F);

        tilesShows = GameObject.FindGameObjectsWithTag("ShowTile");
        foreach (GameObject tilesShow in tilesShows)
            Destroy(tilesShow);

    }
    public abstract void move();
    public abstract void showLegael(Transform transform);
    public virtual void updateArr(string type)
    {
        Pieces.PiecesBoard[(int)position_old.y / 2, (int)position_old.x / 2] = "emp";
        Pieces.PiecesBoard[(int)transform.position.y / 2, (int)transform.position.x / 2] = type;
    }

    public void cantEatSameColor(string type)
    {
        if (Pieces.PiecesBoard[(int)transform.position.y/2, (int)transform.position.x / 2][1] == type[1])
        {
            transform.position = position_old;
            illegal= true;
        }
    }
    public void checkAndMateCheck(string [,] piecesBoard)
    {
        showUI.showCheck(checkForCheckCode.checkCheck('l', piecesBoard), 'l');
        showUI.showCheck(checkForCheckCode.checkCheck('d', piecesBoard), 'd');
        if(checkForCheckCode.checkCheck('d', piecesBoard) || checkForCheckCode.checkCheck('l', piecesBoard))
        {
            sound.check();
        }
        if(checkForCheckCode.checkCheck('d', piecesBoard)|| checkForCheckCode.checkCheck('l', piecesBoard))
        {
            if (checkMateCode.checkMateFunc('d', piecesBoard))
            {
                showUI.showWin('l');
                sound.gameoverCheckmate();
            }
            else if (checkMateCode.checkMateFunc('l', piecesBoard))
            {
                showUI.showWin('d');
                sound.gameoverCheckmate();
            }
        }
    }   
}

