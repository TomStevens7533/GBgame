using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaypoint : MonoBehaviour
{
    EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = gameObject.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
