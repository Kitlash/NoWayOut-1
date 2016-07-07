//BEHAN REMOSHAN
//17-06-2016
using UnityEngine;
using System.Collections;

public class MP_Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        print("HIT");
        var hit = collision.gameObject;
        var health = hit.GetComponent<MP_Health>();
        if (health != null)
        {
            print("HIT in");
            health.TakeDamage(10);
        }

        Destroy(gameObject);
    }
}