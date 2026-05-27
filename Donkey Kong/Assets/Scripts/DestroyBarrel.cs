using Unity.VisualScripting;
using UnityEngine;

public class DestroyBarrel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrel"))
        {
            Destroy(collision.gameObject);
        }
    }
}
