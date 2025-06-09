using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMario : MoveCharacter
{
    private bool _isOnGround = false;

    [SerializeField]
    private Rigidbody2D _rigidbody2D;

    [SerializeField]
    private float _jumpPower = 7f;

    protected override void MoveUp(float speed)
    {
        if (_isOnGround)
        {
            _isOnGround = false;

            _rigidbody2D.velocity
             = Vector3.up * speed * _jumpPower;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)EBlockLayerType.Ground)
        {
            _isOnGround = true;
        }
        if (collision.gameObject.layer == (int)EBlockLayerType.Enemy)
        {
            if (_myDeath.IsDead) return;
            if (collision.isTrigger) return;

            var death = collision.gameObject.GetComponent<DeathBase>();
            if (death != null) death.Die();
            _rigidbody2D.velocity
             = Vector3.up * 3f;
            _isOnGround = true;
        }
        Debug.Log("<color=yellow>Trigger Enter</color>");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)EBlockLayerType.Ground)
        {
            _isOnGround = false;
        }
        Debug.Log("<color=green>Trigger Exit</color>");
    }
}
