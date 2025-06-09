using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharactor : MoveBase
{
    [SerializeField]
    protected DeathBase _myDeath = null;

    // Update is called once per frame
    private new void Update()
    {
        base.Update();

        if (_autoMove == false)
        {
            InputMove();
        }
    }

    private void InputMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveUp(_moveSpeedSec);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft(_moveSpeedSec);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveDown(_moveSpeedSec);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight(_moveSpeedSec);
        }
    }
}
