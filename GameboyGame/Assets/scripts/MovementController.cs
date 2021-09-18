using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    //standard settings
    [SerializeField] private float _standardSpeed;
    [SerializeField] private float _standardAcceleration;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _timeBeforeSlowingDown;

    //brake settings
    [SerializeField] private float _brakeAcceleration;
    [SerializeField] private float _brakeSpeed;
    [SerializeField] private float _brakeGain;
    [SerializeField] private float _resetGainSpeed;


    //max settings
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _maxAcceleration;


    private float _rotSpeed;

    //braking increases when braking
    private float _extraAcceleration;
    private float _extraSpeed;

    //internal variables
    private float _acceleration;
    private float _speed;
    private float _currentSpeed;
    private float _currentSpeedTime;
    private float _axis;

    private bool _isBraking = false;
    private bool _maxGainReached = false;
    private bool _brakeKeyPressed = false;

    // Declaring sprites I want to switch around
    public GameObject _player;
    private SpriteRenderer _spriteR;
    public List<Sprite> _sprites = new List<Sprite>();


    // Start is called before the first frame update
    void Start()
    {
        //set internal variables to standard settings
        _acceleration = _standardAcceleration;
        _speed = _standardSpeed;
        _spriteR = gameObject.GetComponent<SpriteRenderer>();
        //_player 
        _spriteR.sprite = _sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        //left right and a and d input to get current rot
        _rotSpeed = _axis * _rotationSpeed;
        /*if(_rotationSpeed > 0)
        {
            _spriteR.sprite = _sprites[1];
        }*/
        gameObject.transform.eulerAngles += new Vector3(0,0, _rotSpeed);


        if (_currentSpeed < _speed)
            _currentSpeed += _speed * (Time.deltaTime * _acceleration);
        else
            _currentSpeed = _speed;

        Vector3 dir = Quaternion.Euler(gameObject.transform.eulerAngles) * Vector3.up;
        gameObject.transform.position += dir * _currentSpeed * Time.deltaTime;


        //a button gameboy
        if (_brakeKeyPressed)
            PlayerBrake();
        else
        {
            if (_maxGainReached)
            {
                //Set to MaxSpeed & acceleration;
                _acceleration = _standardAcceleration + _extraAcceleration;
                _speed = _standardSpeed + _extraSpeed;
                _maxGainReached = false;
                _extraAcceleration = 0;
                _extraSpeed = 0;
            }
            _isBraking = false;

        }
        if (_currentSpeedTime < _timeBeforeSlowingDown && (_acceleration > _standardAcceleration || _speed > _standardSpeed))
            _currentSpeedTime += Time.deltaTime;
        else {
            //reset to default speed after a while
            if((_acceleration > _standardAcceleration || _speed > _standardSpeed))
            {
                Debug.Log("slowing down");
                _acceleration -= _resetGainSpeed;
                _speed -= _resetGainSpeed;
            }
            else if(_isBraking == false)
            {
                //reset to normal
                _acceleration = _standardAcceleration;
                _speed = _standardSpeed;
                _currentSpeedTime = 0;
                Debug.Log("standard speed");

            }
        }
       
    }

    private void PlayerBrake()
    {
        if (!_isBraking)
        { // mouse button pressed first frame
            _isBraking = true;
            //set internal variables to brake settings
            _acceleration = _brakeAcceleration;
            _speed = _brakeSpeed;
            Debug.Log("Braking");

        }
        else
        {
            while(_extraAcceleration < _maxAcceleration || _extraSpeed < _maxSpeed)
            {
                _extraAcceleration += _brakeGain;
                _extraSpeed += _brakeGain;
            }
            if(!(_extraAcceleration < _maxAcceleration) || !(_extraSpeed < _maxSpeed))
            //max gain reached
            {
                _maxGainReached = true;
                
            }


        }
    }

    public void SetAxis(float axis)
    {
        _axis = axis;
    }

    public void SetIsBraking(bool isBraking)
    {
        _brakeKeyPressed = isBraking;
    }
}
