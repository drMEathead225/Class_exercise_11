using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] WeaponData currentWeapon;
    [SerializeField] LayerMask hittableLayers;
    [SerializeField] float normalFOV = 60f;
    [SerializeField] float zoomSpeed = 10f;

    float nextFireTime;
    int ammo;

    public int Ammo => ammo;

    void Start()
    {
        if (currentWeapon != null) ammo = currentWeapon.magazineSize;
    }

    void Update()
    {
        if (currentWeapon == null)
        {
            Debug.LogWarning("No currentWeapon assigned!");
            return;
        }

        Mouse mouse = Mouse.current;
        if (mouse == null)
        {
            Debug.LogWarning("Mouse.current is null - check Active Input Handling");
            return;
        }

        bool wantsFire = currentWeapon.automatic
            ? mouse.leftButton.isPressed
            : mouse.leftButton.wasPressedThisFrame;

        if (wantsFire)
        {
            Debug.Log($"Click! ammo={ammo}, canFire={CanFire()}");
            if (CanFire())
            {
                RecordShot();
                Shoot();
            }
        }

        bool zooming = mouse.rightButton.isPressed && currentWeapon.zoomFOV < normalFOV;
        float targetFOV = zooming ? currentWeapon.zoomFOV : normalFOV;
        playerCamera.fieldOfView = Mathf.Lerp(
            playerCamera.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
    }

    bool CanFire()
    {
        return ammo > 0 && Time.time >= nextFireTime;
    }

    void RecordShot()
    {
        ammo--;
        nextFireTime = Time.time + currentWeapon.cooldown;
    }

    void Shoot()
    {
        if (Physics.Raycast(
            playerCamera.transform.position,
            playerCamera.transform.forward,
            out RaycastHit hit,
            currentWeapon.range,
            hittableLayers,
            QueryTriggerInteraction.Ignore))
        {
            Debug.Log("Ray hit: " + hit.collider.name);
            EnemyHealth enemy = hit.collider.GetComponentInParent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(currentWeapon.damage);
            }
            else
            {
                Debug.Log("Hit something, but no EnemyHealth found");
            }
        }
        else
        {
            Debug.Log("Ray hit nothing - check Hittable Layers and range");
        }
    }

    public void SetWeapon(WeaponData newWeapon)
    {
        currentWeapon = newWeapon;
        ammo = currentWeapon.magazineSize;
        playerCamera.fieldOfView = normalFOV;
    }

    public void AddAmmo(int amount)
    {
        ammo += amount;
    }
}