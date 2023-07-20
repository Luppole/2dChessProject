using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource startSound;
    public AudioSource moveSound;
    public AudioSource gameoverSound;
    public AudioSource gameoverStalemateSound;
    public AudioSource gameoverCheckmateSound;
    public AudioSource checkSound;
    public AudioSource castlingSound;
    public AudioSource captureSound;
    public AudioSource cantMoveInCheckSound;

    public void move()
    {
        moveSound.Play();
    }
    public void start()
    {
        startSound.Play();
    }
    public void gameover()
    {
        gameoverSound.Play();
    }
    public void gameoverStalemate()
    {
        gameoverStalemateSound.Play();
    }
    public void gameoverCheckmate()
    {
        gameoverCheckmateSound.Play();
    }
    public void capture()
    {
        captureSound.Play();
    }
    public void castling()
    {
        castlingSound.Play();
    }
    public void check()
    {
        checkSound.Play();
    }
    public void cantMoveInCheck()
    {
        cantMoveInCheckSound.Play();
    }
}
