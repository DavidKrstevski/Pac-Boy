using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private Transform movePoint;

    [SerializeField]
    private LayerMask mapLayer;

    private PlayerInput nextInput;
    private PlayerInput lastWorkingInput;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        CheckInputs();

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
            Move();
    }

    private void CheckInputs()
    {
        if (Input.GetAxisRaw("Horizontal") == 1f)
        {
            nextInput = new PlayerInput(1, 0, PlayerInput.State.Right);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1f)
        {
            nextInput = new PlayerInput(-1, 0, PlayerInput.State.Left);
        }
        else if (Input.GetAxisRaw("Vertical") == 1f)
        {
            nextInput = new PlayerInput(0, 1, PlayerInput.State.Up);
        }
        else if (Input.GetAxisRaw("Vertical") == -1f)
        {
            nextInput = new PlayerInput(0, -1, PlayerInput.State.Down);
        }
    }

    private void Move()
    {
        if (nextInput == null)
            return;

        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(nextInput.X, nextInput.Y, 0f), .2f, mapLayer))
        {
            movePoint.position += new Vector3(nextInput.X, nextInput.Y, 0f);
            lastWorkingInput = nextInput;
        }
        else
        {
            if (lastWorkingInput == null)
                return;

            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(lastWorkingInput.X, lastWorkingInput.Y, 0f), .2f, mapLayer))
            {
                movePoint.position += new Vector3(lastWorkingInput.X, lastWorkingInput.Y, 0f);
            }
        }
    }
}
