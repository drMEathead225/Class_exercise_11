using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int amount = 10;

    void OnTriggerEnter(Collider other)
    {
        WeaponController controller = other.GetComponentInChildren<WeaponController>();
        if (controller != null)
        {
            controller.AddAmmo(amount);
            gameObject.SetActive(false);
        }
    }
}