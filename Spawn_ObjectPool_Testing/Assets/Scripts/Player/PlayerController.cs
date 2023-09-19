using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;

    private Rigidbody _rb;
    [SerializeField] SpriteRenderer _sr;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x, 0, y);
        _rb.velocity = moveDir * _moveSpeed;

        if (x != 0 && x < 0)
        {
            _sr.flipX = true;
        }
        else if (x != 0 && x > 0)
        {
            _sr.flipX = false;
        }
    }
}
