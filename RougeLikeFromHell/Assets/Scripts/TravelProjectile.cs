using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelProjectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    //Событие при попадании снаряда в объект
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageRegistration damageScript = collision.GetComponent<DamageRegistration>();
        if (damageScript != null)
        {
            damageScript.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
