using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.position += new Vector3(x, 0, z) * speed * Time.deltaTime;
    }
}