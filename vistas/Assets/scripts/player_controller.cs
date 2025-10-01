using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    private CharacterController _player;
    [SerializeField] private float _movespeed, _gravity, _fallvelocity, _jumpforve;
    private Vector3 _axis, _moveplayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        _player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        _axis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (_axis.magnitude > 1) _axis = transform.TransformDirection(_axis).normalized;
        else _axis = transform.TransformDirection(_axis);

        _moveplayer.x = _axis.x;
        _moveplayer.z = _axis.z;
        setgravity();
        
        _player.Move(_moveplayer * _movespeed * Time.deltaTime);
    }
    private void setgravity()
    {
        if (_player.isGrounded)
        {
            _fallvelocity = -_gravity * Time.deltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                _fallvelocity = _jumpforve;
            }
        }
        else
        {
            _fallvelocity -= _gravity * Time.deltaTime;
        }
        _moveplayer.y = _fallvelocity;
    }
}
