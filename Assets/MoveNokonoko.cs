using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// のこのこを動かすスクリプト
/// </summary>
public class MoveNokonoko : MoveCharacter
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (_eMoveType)
        {
            case EMoveType.Left:
                _eMoveType = EMoveType.Right;
                break;
            case EMoveType.Right:
                _eMoveType = EMoveType.Left;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)EBlockLayerType.Player)
        {
            if (_myDeath.IsDead) return;
            if (collision.isTrigger) return;

            var death = collision.gameObject.GetComponent<DeathBase>();
            if (death != null) death.Die();
        }
        Debug.Log("<color=cyan>NokoNoko Trigger Enter</color>");
    }
}
