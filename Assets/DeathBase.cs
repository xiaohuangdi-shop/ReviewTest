using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeathBase : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera = null;

    [SerializeField]
    protected bool _isDead = false;
    /// <summary>
    /// 死んだかどうか検討する変数フラグ
    /// 死亡後 true
    /// デフォルト false
    /// </summary>
    public bool IsDead => _isDead;
    
    private readonly Rect _viewRect = new Rect(0f, 0f, 1f, 1f);

    public virtual void Die()
    {
        _isDead = true;
    }

    // Update is called once per frame
    protected void Update()
    {
        // 死んでいて、画面外に出たら、GameObjectごとDestory処理
        if (_isDead)
        {
            Vector3 min = this.transform.position
                 + new Vector3(-2, -2, 0f);
            Vector3 max = this.transform.position
                 + new Vector3(2, 2, 0f);

            var isVisible = _viewRect.Contains(_mainCamera.WorldToViewportPoint(min))
                 || _viewRect.Contains(_mainCamera.WorldToViewportPoint(max));

            if (isVisible == false)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
