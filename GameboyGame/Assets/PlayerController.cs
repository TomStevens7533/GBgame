using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private MovementController _movementController;
    private PickUpScripts _PickUpController;
    void Awake()
    {
        _movementController = GetComponent<MovementController>();
        _PickUpController = GetComponent<PickUpScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal movement
        _movementController.SetAxis(Input.GetAxisRaw("Horizontal"));

        //brake movement
        _movementController.SetIsBraking(Input.GetMouseButton(0));

        float verticalAxis = Input.GetAxisRaw("Vertical");
        if (!Mathf.Approximately(Input.GetAxisRaw("Vertical"), 0))
              _PickUpController.FireRocket(_movementController.GetPlayerEuler(), verticalAxis);

        if (Input.GetMouseButton(1))
            _movementController.StartSpeedBoost();
    }
}
