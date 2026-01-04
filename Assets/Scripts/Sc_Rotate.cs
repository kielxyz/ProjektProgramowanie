using UnityEngine;

public class Sc_Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 250f;

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
