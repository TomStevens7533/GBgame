using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementController : MonoBehaviour
{
    public enum AIMode { followPlayer, followWaypoints };

    [Header("AI settings")]
    public AIMode aiMode;

    Vector3 targetPosition = Vector3.zero;
    Transform targetTransform = null;

    MovementController movementController;

    // Start is called before the first frame update
    void Start()
    {
        movementController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 inputVector = Vector2.zero;
        /*
        switch(aiMode)
        {
            case AIMode.followPlayer:
                Fo
        }*/
        inputVector.x = 16.0f;
        inputVector.y = 16.0f;

        //movementController. = inputVector.y;
        //movementController.SetInputVector(inputVector);
    }

    void FollowPlayer()
    {
        ;
    }
}
