using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _player;
    public float force = 30;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        
    }
    private void FixedUpdate()
    {
        _player.AddForce(0,0,force);
    }

    private void Jump()
    {
        if (_player)
        {
            if(Mathf.Abs(_player.velocity.y) < 0.0005f)
            {
                _player.AddForce(0,force,0);
            }
        }
    }
}
