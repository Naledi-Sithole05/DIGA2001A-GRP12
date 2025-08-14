using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    private Vector3 startPosition;
    private Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;

        // Try to find a Rigidbody on this object or its parents
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = GetComponentInParent<Rigidbody>();
        }

        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on Player or its parents!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Beam"))
        {
            ResetPlayer();
        }
    }

    void ResetPlayer()
    {
        transform.position = startPosition;

        if (rb != null)
        {
#if UNITY_6000_0_OR_NEWER
            rb.linearVelocity = Vector3.zero; // New Unity Physics
#else
            rb.velocity = Vector3.zero;
#endif
            rb.angularVelocity = Vector3.zero;
        }
    }
}
