using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Transform movePoint;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            Debug.Log("Collided");

            collision.gameObject.SetActive(false);

            //Add Points to Score
            //Check if all points have been collected
        }
    }
}
