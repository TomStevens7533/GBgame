using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketUsable : MonoBehaviour
{
    [SerializeField] private GameObject _explostionGo;
    private Vector3 _velocity;
    private Quaternion _currentRot;
    private Rigidbody2D _rigidBody;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.layer == 8)
        { //hits obstacles
            Debug.Log(col.gameObject.layer);
            var go = Instantiate(_explostionGo);
            go.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y, -3);
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        _rigidBody.MovePosition(gameObject.transform.position + (new Vector3(_velocity.x, _velocity.y, 0)));
    }

    public void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
    }
    public void SetRotation(Quaternion q)
    {
        _currentRot = q;
        _rigidBody.SetRotation(q);
    }
  
}
