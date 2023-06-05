using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private PlayerInputs _playerInputs;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveInput;

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
        
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }

    private void FixedUpdate()
    {
        _moveInput = _playerInputs.PlayerInputMap.Movement.ReadValue<Vector2>();
        //_moveInput.y = 0f;
        _rigidbody2D.velocity = _moveInput * _speed;
    }
}
