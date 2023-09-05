using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEffectManager : MonoBehaviour
{
    [SerializeField] private GameObject pfStar;
    [SerializeField] private List<Transform> starSpawnPositions;

    private float starSpawnTimer;
    private float starSpawnTimerMax = .2f;


    private bool hasWon;

    private void Start()
    {
        hasWon = false;

        starSpawnTimer = starSpawnTimerMax;
    }

    private void OnEnable()
    {
        //Subscribe to win event
        PieceManager.Instance.OnWin += Instance_OnWin;
    }


    private void OnDisable()
    {
        //Unsubscribe from win event
        PieceManager.Instance.OnWin -= Instance_OnWin;
    }
    private void Update()
    {
        if (!hasWon) return;

        starSpawnTimer -= Time.deltaTime;

        if (starSpawnTimer < 0f)
        {
            int randomSpawnIndex = Random.Range(0, starSpawnPositions.Count);
            Instantiate(pfStar, starSpawnPositions[randomSpawnIndex].position, Quaternion.identity);
            starSpawnTimer += starSpawnTimerMax;
        }
    }
    private void Instance_OnWin(PieceManager obj)
    {
        hasWon = true;
    }

}
