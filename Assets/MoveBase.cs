using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveBase : MonoBehaviour
{
    public enum EMoveType
    {
        None = 0,
        Left,
        Right,
        Up,
        Down,
    }

    public enum EBlockLayerType
    {
        Player = 7,
        Enemy = 8,
        Ground = 6,
    }

    [SerializeField]
    protected EMoveType _eMoveType = EMoveType.None;

    [SerializeField]
    protected float _moveSpeedSec = 1f;

    [SerializeField]
    protected bool _autoMove = false;

    // Update is called once per frame
    protected void Update()
    {
        // ガード節　オート機能がOFFだった場合は以降なにもしない
        if (_autoMove == false) return;

        switch (_eMoveType)
        {
            case EMoveType.Left:
                MoveLeft(_moveSpeedSec);
                break;
            case EMoveType.Right:
                MoveRight(_moveSpeedSec);
                break;
            case EMoveType.Up:
                MoveUp(_moveSpeedSec);
                break;
            case EMoveType.Down:
                MoveDown(_moveSpeedSec);
                break;
        }
    }

    protected void MoveLeft(float speed)
    {
        this.transform.position
         += Vector3.left * speed * Time.deltaTime;
    }
    protected void MoveRight(float speed)
    {
        this.transform.position
         += Vector3.right * speed * Time.deltaTime;
    }
    protected virtual void MoveUp(float speed)
    {
        this.transform.position
         += Vector3.up * speed * Time.deltaTime;
    }
    protected virtual void MoveDown(float speed)
    {
        this.transform.position
         += Vector3.down * speed * Time.deltaTime;
    }
    
}
