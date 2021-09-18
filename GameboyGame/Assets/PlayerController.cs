using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private MovementController _movementController;
    void Awake()
    {
        _movementController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        _movementController.SetAxis(Input.GetAxisRaw("Horizontal"));
        _movementController.SetIsBraking(Input.GetMouseButton(0));
    }
}
