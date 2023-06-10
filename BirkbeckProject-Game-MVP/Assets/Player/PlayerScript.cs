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

    void Awake()
    {
        _playerInputs = new PlayerInputs();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _jumpAmmo = 3;
        _health = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInputs.PlayerInputMap.Jump.triggered & _jumpAmmo > 0)
        {
            _jumpAmmo -= 1;
            Jump();
        }
        _moveInput = _playerInputs.PlayerInputMap.Movement.ReadValue<Vector2>();
        _rigidbody2D.AddForce(transform.right * _moveInput * _speed);
    }

    void FixedUpdate()
    {

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
}
