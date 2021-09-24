using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Waypoints for the Enemy Racers
    [SerializeField] Transform[] waypoints;
    // Movement Speed 
    [SerializeField] float moveSpeed = 2f;
    
    private int waypointIndex;
    private Rigidbody2D _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        
        if (waypointIndex <= waypoints.Length-1)
        {
            //transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * moveSpeed);

            Vector2 waypointVector = new Vector2(waypoints[waypointIndex].transform.position.x, waypoints[waypointIndex].transform.position.y);
            _rigidBody.velocity = waypointVector * moveSpeed * Time.deltaTime;

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }

            if(waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        waypointIndex += 1;
    }

}
