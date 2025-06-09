using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNokonoko : MoveCharactor
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (eMoveType)
        {
            case EMoveType.Left:
                eMoveType = EMoveType.Right;
                break;
            case EMoveType.Right:
                eMoveType = EMoveType.Left;
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
