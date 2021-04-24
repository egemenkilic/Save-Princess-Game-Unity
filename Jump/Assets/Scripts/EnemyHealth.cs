using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;

    public void GetDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
