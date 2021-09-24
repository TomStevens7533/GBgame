using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("collided");
            collision.GetComponent<PickUpScripts>().IncreaseRocketAmounnt();
        }
    }
}
