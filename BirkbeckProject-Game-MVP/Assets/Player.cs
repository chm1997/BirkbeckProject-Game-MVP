using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    private PlayerInputs _playerInputs;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveInput;
    private Vector2 _jumpInput;

    void Awake()
    {
        _playerInputs = new PlayerInputs();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_rigidbody2D is null) Debug.LogError("Rigidbody2D is null");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInputs.PlayerInputMap.Jump.triggered) Jump();
        _moveInput = _playerInputs.PlayerInputMap.Movement.ReadValue<Vector2>();
        _rigidbody2D.AddForce(transform.right * _moveInput *_speed);

        //_moveInput = _playerInputs.PlayerInputMap.Movement.ReadValue<Vector2>();
        //_rigidbody2D.velocity = _moveInput * _speed;
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(transform.up * _jumpForce);
    }
}
