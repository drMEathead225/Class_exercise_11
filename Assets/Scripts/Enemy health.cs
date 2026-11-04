using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}