using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBox : MonoBehaviour
{
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
