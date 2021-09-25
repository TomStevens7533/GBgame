using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplostionScript : MonoBehaviour
{
    [SerializeField] private float _maxLifeTime;
    private float _currentSeconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentSeconds < _maxLifeTime)
        {
            _currentSeconds += Time.deltaTime;
        }
        else
        {   //expired
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        { //player hit by explion need to implement ai
            Debug.Log("player exploded");
            collision.gameObject.GetComponent<MovementController>().GetHit();
        }

    }
}
