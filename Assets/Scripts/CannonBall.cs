using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Attacked(1);
        }
        else if (collision.CompareTag("EnemyShooter"))
        {
            collision.gameObject.GetComponent<EnemyShooter>().Attacked(1);
        }
        else if (collision.CompareTag("EnemyChaser"))
        {
            collision.gameObject.GetComponent<EnemyChaser>().Attacked(1);
        }
        Destroy(gameObject);
    }
}
