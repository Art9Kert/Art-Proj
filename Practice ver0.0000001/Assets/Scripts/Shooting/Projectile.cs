using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float lifeTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Invoke("DestroyProjectile",lifeTime);
    }
    
    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
