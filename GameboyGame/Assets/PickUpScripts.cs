using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScripts : MonoBehaviour
{
    [SerializeField] private GameObject _rocketGameObject;
    [SerializeField] private float _RocketSpeed = 5f;

    private int _RocketAvailable = 0;
    private bool _SpeedBoost = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpeedBoost()
    {
        _SpeedBoost = true;
    }

    public void IncreaseRocketAmounnt()
    {
        _RocketAvailable++;
    }
    public void UseSpeedBoost()
    {
        _SpeedBoost = false;
    }
    public void FireRocket(Vector3 euler, float verticalAxis)
    {
        //Fire rocket
        if(_RocketAvailable > 0)
        {
            _RocketAvailable--;
            Debug.Log("Fire");
            var go = Instantiate(_rocketGameObject);
            go.transform.position = gameObject.transform.position;
            Quaternion currentRotation = (verticalAxis > 0 ? Quaternion.Euler(euler) : Quaternion.Euler(new Vector3(0, 0, (euler.z + 180) % 360)));
            Vector3 dir = currentRotation * Vector3.up;
            Vector3 veloctie = dir * _RocketSpeed * Time.deltaTime;
            go.GetComponent<RocketUsable>().SetVelocity(veloctie);
            go.GetComponent<RocketUsable>().SetRotation(currentRotation);

            //go.transform.rotation = Quaternion.LookRotation(newVelocity, Vector3.up);
        }
    }
}
