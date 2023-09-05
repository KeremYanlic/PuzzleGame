using System;

ing System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private float startSpeed;
    private Rigidbody2D starRB;


    private void Start()
    {
        startSpeed = Random.Range(0, 10);

        starRB = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            starRB.velocity = transform.up * startSpeed;
        }
    }
}
