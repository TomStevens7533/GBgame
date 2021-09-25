using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("speed collided");
            collision.gameObject.GetComponent<MovementController>().AddSpeedBoost();

        }
    }
}
