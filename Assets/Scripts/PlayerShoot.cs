using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float range = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position,
                            playerCamera.transform.forward,
                            out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            EnemyHealth health = hit.transform.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage(1);
            }
        }
    }
}