using System;
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

        Debug.Log("Owch! Enemy took damage.");
    }

    internal void TakeDamage(object damage)
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Owch! Enemy took damage.");
        }
    }
}