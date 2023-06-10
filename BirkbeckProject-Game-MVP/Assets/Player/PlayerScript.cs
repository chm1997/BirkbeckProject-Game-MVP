using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private int _jumpAmmo;
    [SerializeField]
    private int _health;
    

    private PlayerInputs _playerInputs;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveInput;
    private Vector2 _jumpInput;
    [SerializeField]
    private bool _isGrounded;

    private void Awake()
    {
        _playerInputs = new PlayerInputs();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _jumpAmmo = 3;
        _health = 5;
        _isGrounded = false;
    }

    private void Update()
    {
        if (_playerInputs.PlayerInputMap.Jump.triggered & _jumpAmmo > 0 & _isGrounded)
        {
            _jumpAmmo -= 1;
            Jump();
            _isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        _moveInput = _playerInputs.PlayerInputMap.Movement.ReadValue<Vector2>();
        float verticalMomentum = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = new Vector2(_moveInput.x * _speed, verticalMomentum);
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

    public int GetJumpAmmo()
    {
        return _jumpAmmo;
    }

    public int GetHealth()
    {
        return _health;
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        _health -= 1;
    }

    private void OnCollisionEnter2D()
    {
        _isGrounded = true;
    }
}
