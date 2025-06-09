using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathNokonoko : DeathBase
{

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
            this.transform.rotation *= Quaternion.Euler(0f, 0f, 180f);

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
