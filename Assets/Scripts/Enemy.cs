using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudparticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bird bird1 = collision.collider.GetComponent<bird>();
        if (bird1 != null)
        {
            Instantiate(_cloudparticles,transform.position,Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        if (collision.contacts[0].normal.y > -0.5)
        {
            Instantiate(_cloudparticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}



