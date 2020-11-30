using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Ghost : MonoBehaviour
{
    public Vector2 startingPosition;

    [SerializeField]
    private Transform[] corners;

    [Space]

    [SerializeField]
    private AIDestinationSetter playerDestinationSetter;

    [SerializeField]
    private AIDestinationSetter cornerDestinationSetter;

    [Space]

    [SerializeField]
    private float chaseDuration = 10f;

    [SerializeField]
    private float scatterDuration = 5f;

    private float chaseTimer;
    private float scatterTimer;

    private bool scattering;

    private void Awake()
    {
        startingPosition = transform.position;
        chaseTimer = chaseDuration;
    }

    private void Update()
    {
        if (chaseTimer <= 0)
        {
            if (!scattering)
            {
                scattering = true;
                cornerDestinationSetter.target = corners[Random.Range(0, corners.Length)];
                playerDestinationSetter.enabled = false;
                cornerDestinationSetter.enabled = true;
                scatterTimer = scatterDuration;
            }

            if (scatterTimer <= 0)
            {         
                chaseTimer = chaseDuration;
                cornerDestinationSetter.enabled = false;
                playerDestinationSetter.enabled = true;
            }
            else
                scatterTimer -= Time.deltaTime;
        }
        else
            chaseTimer -= Time.deltaTime;
    }
}
