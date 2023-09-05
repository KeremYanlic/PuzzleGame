using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public bool isCorrect = false;

    private void Start()
    {
        int randomIndex = Random.Range(0, 4);

        switch (randomIndex)
        {
            case 0:
                transform.eulerAngles = new Vector3(0, 0, 0);
                isCorrect = true;
                break;
            case 1:
                transform.eulerAngles = new Vector3(0, 0, 90);
                isCorrect = false;
                break;
            case 2:
                transform.eulerAngles = new Vector3(0, 0, 180);
                isCorrect = false;
                break;
            case 3:
                transform.eulerAngles = new Vector3(0, 0, 270);
                isCorrect = false;
                break;
        }
    }

}