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

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Input.GetAxisRaw("Horizontal") == 1f)
            {
                MoveHorizontal();
                //Make Player look right
            }
            else if (Input.GetAxisRaw("Horizontal") == -1f)
            {
                MoveHorizontal();
                //Make Player look left
            }
            else if (Input.GetAxisRaw("Vertical") == 1f)
            {
                MoveVertical();
                //Make Player look up
            }
            else if (Input.GetAxisRaw("Vertical") == -1f)
            {
                MoveVertical();
                //Make Player look down
            }
        }
    }

    private void MoveHorizontal()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, mapLayer))
        {
            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        }
    }

    private void MoveVertical()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, mapLayer))
        {
            movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
        }
    }
}
