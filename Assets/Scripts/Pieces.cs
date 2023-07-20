using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject rlt;
    [SerializeField] private GameObject rdt;
    [SerializeField] private GameObject qlt;
    [SerializeField] private GameObject qdt;
    [SerializeField] private GameObject plt;
    [SerializeField] private GameObject pdt;
    [SerializeField] private GameObject nlt;
    [SerializeField] private GameObject ndt;
    [SerializeField] private GameObject klt;
    [SerializeField] private GameObject kdt;
    [SerializeField] private GameObject blt;
    [SerializeField] private GameObject bdt;

    //public static PieceClass[,] PiecesBoard ={
    //    {new Rook("white"),new Knight("white"),new Bishop("white"),new Queen("white"),new King("white"),new Bishop("white"),new Knight("white"),new Rook("white")},
    //    {new Pawn("white"),new Pawn("white"),new Pawn("white"),new Pawn("white"),new Pawn("white"),new Pawn("white"),new Pawn("white"),new Pawn("white")},
    //    {new Emp(),new Emp(),new Emp(),new Emp(),new Emp(),new Emp(),new Emp(),new Emp()},
    //    {new Emp(),new Emp(),new Emp(),new Emp(),new Emp(),new Emp(),new Emp(),new Emp()},
    //    {new Emp(),new Emp(),new Emp(),new Emp(),new Emp(),new Emp(),new Emp(),new Emp()},
    //    {new Emp(),new Emp(),new Emp(),new Emp(),new Emp(),new Emp(),new Emp(),new Emp()},
    //    {new Pawn("black"),new Pawn("black"),new Pawn("black"),new Pawn("black"),new Pawn("black"),new Pawn("black"),new Pawn("black"),new Pawn("black")},
    //    {new Rook("black"),new Knight("black"),new Bishop("black"),new Queen("black"),new King("black"),new Bishop("black"),new Knight("black"),new Rook("black")}};
    //public static PieceClass[,] PiecesBoard = new PieceClass[8, 8];
    public static GameObject[,] Board = new GameObject[8,8];
    public static string[,] PiecesBoard ={
        {"rlt","nlt","blt","qlt","klt","blt","nlt","rlt"},
        {"plt","plt","plt","plt","plt","plt","plt","plt"},
        {"emp","emp","emp","emp","emp","emp","emp","emp"},
        {"emp","emp","emp","emp","emp","emp","emp","emp"},
        {"emp","emp","emp","emp","emp","emp","emp","emp"},
        {"emp","emp","emp","emp","emp","emp","emp","emp"},
        {"pdt","pdt","pdt","pdt","pdt","pdt","pdt","pdt"},
        {"rdt","ndt","bdt","qdt","kdt","bdt","ndt","rdt"}};
    //public static string[,] PiecesBoard ={
    //    {"rlt","nlt","blt","qlt","klt","blt","nlt","rlt"},
    //    {"plt","plt","plt","plt","plt","plt","plt","plt"},
    //    {"emp","emp","emp","emp","emp","emp","emp","emp"},
    //    {"emp","emp","emp","emp","emp","emp","emp","emp"},
    //    {"emp","emp","emp","emp","emp","emp","emp","emp"},
    //    {"emp","emp","emp","emp","emp","emp","emp","emp"},
    //    {"pdt","pdt","pdt","pdt","pdt","pdt","pdt","pdt"},
    //    {"pdt","ndt","pdt","pdt","kdt","pdt","ndt","pdt"}};
    public GameObject game;
    public checkForCheck checkForCheckCode;
    public checkMate checkMateCode;
    public Sound sound;
    public ShowUI showUI;
    void Start()
    {
        game = GameObject.Find("Game");
        checkForCheckCode = (checkForCheck)game.GetComponent(typeof(checkForCheck));
        showUI = (ShowUI)game.GetComponent(typeof(ShowUI));
        checkMateCode = (checkMate)game.GetComponent(typeof(checkMate));
        sound = (Sound)game.GetComponent(typeof(Sound));
        GeneratePieces(); 
    }
    public void GeneratePromotion(int x, int y, string toMake)
    {
        PiecesBoard[y / 2, x / 2] = toMake;
        showUI.showCheck(checkForCheckCode.checkCheck('l', PiecesBoard), 'l');
        showUI.showCheck(checkForCheckCode.checkCheck('d', PiecesBoard), 'd');
        if(checkForCheckCode.checkCheck('d', PiecesBoard) || checkForCheckCode.checkCheck('l', PiecesBoard))
        {
            sound.check();
        }
        if(checkForCheckCode.checkCheck('d', PiecesBoard)|| checkForCheckCode.checkCheck('l', PiecesBoard))
        {
            if (checkMateCode.checkMateFunc('d', PiecesBoard))
            {
                showUI.showWin('l');
                sound.gameoverCheckmate();
            }
            else if (checkMateCode.checkMateFunc('l', PiecesBoard))
            {
                showUI.showWin('d');
                sound.gameoverCheckmate();
            }
        }
        
        switch (toMake)
        {
            case "rlt":
                var spawnedRlt = Instantiate(rlt, new Vector3(x, y), Quaternion.identity);
                spawnedRlt.name = $"rlt {x*2} {y*2}";
                spawnedRlt.gameObject.AddComponent<Rook>().type = "rlt";
                break;
            case "rdt":
                var spawnedRdt = Instantiate(rdt, new Vector3(x, y), Quaternion.identity);
                spawnedRdt.name = $"rdt {x* 2} {y * 2}";
                spawnedRdt.gameObject.AddComponent<Rook>().type = "rdt";
                break;
            case "nlt":
                var spawnedNlt = Instantiate(nlt, new Vector3(x, y), Quaternion.identity);
                spawnedNlt.name = $"nlt {x * 2} {y * 2}";
                spawnedNlt.gameObject.AddComponent<Knight>().type = "nlt";
                break;
            case "ndt":
                var spawnedNdt = Instantiate(ndt, new Vector3(x, y), Quaternion.identity);
                spawnedNdt.name = $"ndt {x * 2} {y * 2}";
                spawnedNdt.gameObject.AddComponent<Knight>().type = "ndt";
                break;
            case "blt":
                var spawnedBlt = Instantiate(blt, new Vector3(x, y), Quaternion.identity);
                spawnedBlt.name = $"blt {x * 2} {y * 2}";
                spawnedBlt.gameObject.AddComponent<Bishop>().type = "blt";
                break;
            case "bdt":
                var spawnedBdt = Instantiate(bdt, new Vector3(x, y), Quaternion.identity);
                spawnedBdt.name = $"bdt {x * 2} {y * 2}";
                spawnedBdt.gameObject.AddComponent<Bishop>().type = "bdt";
                break;
            case "qlt":
                var spawnedQlt = Instantiate(qlt, new Vector3(x, y), Quaternion.identity);
                spawnedQlt.name = $"qlt {x * 2} {y * 2}";
                spawnedQlt.gameObject.AddComponent<Queen>().type = "qlt";
                break;
            case "qdt":
                var spawnedQdt = Instantiate(qdt, new Vector3(x, y), Quaternion.identity);
                spawnedQdt.name = $"qdt {x * 2} {y * 2}";
                spawnedQdt.gameObject.AddComponent<Queen>().type = "qdt";
                break;

        }
    }

    void GeneratePieces() {
        for (int x = 0; x < 8; x++) {
            for (int y = 0; y < 8; y++) {
                switch (PiecesBoard[y, x])
                {
                    case "rlt":
                        var spawnedRlt = Instantiate(rlt, new Vector3(x*2, y*2), Quaternion.identity);
                        spawnedRlt.name = $"rlt {x * 2} {y * 2}";
                        Board[x, y] = spawnedRlt;
                        spawnedRlt.gameObject.AddComponent<Rook>().type = "rlt";
                        break;
                    case "rdt":
                        var spawnedRdt = Instantiate(rdt, new Vector3(x*2, y*2), Quaternion.identity);
                        spawnedRdt.name = $"rdt {x * 2} {y * 2}";
                        Board[x, y] = spawnedRdt;
                        spawnedRdt.gameObject.AddComponent<Rook>().type = "rdt";
                        break;    
                    case "nlt":
                        var spawnedNlt = Instantiate(nlt, new Vector3(x*2, y*2), Quaternion.identity);
                        spawnedNlt.name = $"nlt {x * 2} {y * 2}";
                        Board[x, y] = spawnedNlt;
                        spawnedNlt.gameObject.AddComponent<Knight>().type = "nlt";
                        break;
                    case "ndt":
                        var spawnedNdt = Instantiate(ndt, new Vector3(x*2, y*2), Quaternion.identity);
                        spawnedNdt.name = $"ndt {x * 2} {y * 2}";
                        Board[x, y] = spawnedNdt;
                        spawnedNdt.gameObject.AddComponent<Knight>().type = "ndt";
                        break;   
                    case "blt":
                        var spawnedBlt = Instantiate(blt, new Vector3(x*2, y*2), Quaternion.identity);
                        spawnedBlt.name = $"blt {x * 2} {y * 2}";
                        Board[x, y] = spawnedBlt;
                        spawnedBlt.gameObject.AddComponent<Bishop>().type = "blt";
                        break;
                    case "bdt":
                        var spawnedBdt = Instantiate(bdt, new Vector3(x*2, y*2), Quaternion.identity);
                        spawnedBdt.name = $"bdt {x * 2} {y * 2}";
                        Board[x, y] = spawnedBdt;
                        spawnedBdt.gameObject.AddComponent<Bishop>().type = "bdt";
                        break;   
                    case "qlt":
                        var spawnedQlt = Instantiate(qlt, new Vector3(x*2, y*2), Quaternion.identity);
                        spawnedQlt.name = $"qlt {x *2} {y * 2}";
                        Board[x, y] = spawnedQlt;
                        spawnedQlt.gameObject.AddComponent<Queen>().type = "qlt";
                        break;
                    case "qdt":
                        var spawnedQdt = Instantiate(qdt, new Vector3(x*2, y*2), Quaternion.identity);
                        spawnedQdt.name = $"qdt {x * 2} {y * 2}";
                        Board[x, y] = spawnedQdt;
                        spawnedQdt.gameObject.AddComponent<Queen>().type = "qdt";
                        break;   
                    case "klt":
                        var spawnedKlt = Instantiate(klt, new Vector3(x*2, y*2), Quaternion.identity);
                        spawnedKlt.name = $"klt {x * 2} {y * 2}";
                        Board[x, y] = spawnedKlt;
                        spawnedKlt.gameObject.AddComponent<King>().type = "klt";
                        break;
                    case "kdt":
                        var spawnedKdt = Instantiate(kdt, new Vector3(x*2, y*2), Quaternion.identity);
                        spawnedKdt.name = $"kdt {x * 2} {y * 2}";
                        Board[x, y] = spawnedKdt;
                        spawnedKdt.gameObject.AddComponent<King>().type = "kdt";
                        break;   
                    case "plt":
                        var spawnedPlt = Instantiate(plt, new Vector3(x*2, y*2), Quaternion.identity);
                        spawnedPlt.name = $"plt {x * 2} {y * 2}";
                        Board[x, y] = spawnedPlt;
                        spawnedPlt.gameObject.AddComponent<Pawn>().type = "plt";
                        break;
                    case "pdt":
                        var spawnedPdt = Instantiate(pdt, new Vector3(x*2, y*2), Quaternion.identity);
                        spawnedPdt.name = $"pdt {x * 2} {y * 2}";
                        Board[x, y] = spawnedPdt;
                        spawnedPdt.gameObject.AddComponent<Pawn>().type = "pdt";
                        break;                       
                }
                
            }
        }
    }
}
