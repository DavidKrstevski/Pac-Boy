using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private Transform teleporter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = teleporter.position;
        Player.instance.movePoint.position = teleporter.position;
    }
}
