using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DeathMario : DeathBase
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected new void Update()
    {
        base.Update();
    }


    public override void Die()
    {
        if (_isDead == false)
        {
            // 演出
            var rb = this.GetComponent<Rigidbody2D>();

            if (rb != null) rb.velocity += Vector2.up * 3f;
            // 縦の大きさを半分にする
            var scale = this.transform.localScale;
            scale.y *= 0.5f;
            this.transform.localScale = scale;

            // 張り付けられているcollisionを全てOFF
            Collider2D[] colliders = this.GetComponents<Collider2D>();
            if (colliders != null && colliders.Length > 0)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    colliders[i].enabled = false;
                }
            }
        }

        base.Die();
    }
}
