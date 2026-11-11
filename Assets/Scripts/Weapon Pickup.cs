using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] WeaponData weapon;

    void OnTriggerEnter(Collider other)
    {
        WeaponController controller = other.GetComponentInChildren<WeaponController>();
        if (controller != null)
        {
            controller.SetWeapon(weapon);
            gameObject.SetActive(false);
        }
    }
}