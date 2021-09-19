using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Camera _camera;

    void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //follow player
        transform.position = new Vector3((_player.transform.position.x / 2) - 1.6f,( _player.transform.position.y / 2) - 1.44f, transform.position.z);
    }
}
