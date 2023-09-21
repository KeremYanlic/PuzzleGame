using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PieceManager : SingletonMonobehaviour<PieceManager>
{
    public event Action<PieceManager> OnWin;


    public int counter = 0;

    private bool hasWon = false;

    private void OnEnable()
    {
        //Subscribe to win event
        OnWin += PieceManager_OnWin;
    }
    private void OnDisable()
    {
        //Unsubscribe from win event
        OnWin -= PieceManager_OnWin;
    }

    private void PieceManager_OnWin(PieceManager obj)
    {
        SoundManager.Instance.PlayClip(GameResources.Instance.winAudioClip, 1f);
        SoundManager.Instance.PlayClip(GameResources.Instance.clapAudioClip, 0.8f);
    }


    private void Update()
    {
        if (hasWon) return;

        if (counter >= GetPieceCount())
        {
            hasWon = true;
            CallWinEvent();
            return;
        }


        if (Input.GetMouseButtonDown(0))
        {
            counter = 0;
            RaycastHit2D hit = Physics2D.Raycast(UtilsClass.GetMouseWorldPosition(), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<Piece>().isCorrect)
                {
                    SoundManager.Instance.PlayClip(GameResources.Instance.errorAudioClip, .8f);
                    return;
                }
                RotatePiece(hit.collider.gameObject);

                foreach (GameObject piece in GetPuzzlePieces())
                {
                    if (piece.GetComponent<Piece>().isCorrect)
                    {
                        counter++;
                    }
                }

            }
        }
    }



    private void RotatePiece(GameObject gameObject)
    {
        gameObject.transform.eulerAngles += new Vector3(0, 0, 90);
        Piece piece = gameObject.gameObject.GetComponent<Piece>();

        piece.isCorrect = true ?
            Mathf.RoundToInt(gameObject.transform.eulerAngles.z) == 0 :
            Mathf.RoundToInt(gameObject.transform.eulerAngles.z) != 0;


        if (piece.isCorrect)
        {
            SoundManager.Instance.PlayClip(GameResources.Instance.clickAudioClip, 1f);
            SoundManager.Instance.PlayClip(GameResources.Instance.dingAudioClip, 1f);
        }
        else
        {
            SoundManager.Instance.PlayClip(GameResources.Instance.clickAudioClip, 1f);
        }
    }



    private List<GameObject> GetPuzzlePieces()
    {
        return GameObject.FindGameObjectsWithTag(Settings.pieceTag).ToList();
    }
    private int GetPieceCount()
    {
        return GameObject.FindGameObjectsWithTag(Settings.pieceTag).ToList().Count();
    }
    public void CallWinEvent()
    {
        OnWin?.Invoke(this);
    }
}
