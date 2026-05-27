using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth = 3;
    [SerializeField] private GameObject health1;
    [SerializeField] private GameObject health2;
    [SerializeField] private GameObject health3;


    private void Start()
    {
       if(PlayerPrefs.HasKey("PlayerHealth"))
            currentHealth = PlayerPrefs.GetInt("PlayerHealth");
            
       else
            PlayerPrefs.SetInt("PlayerHealth", 3);

       if(currentHealth<= 0)
        {
            currentHealth = 3;
            PlayerPrefs.SetInt("PlayerHealth", currentHealth);
        }

       UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        currentHealth = Mathf.Clamp(currentHealth, 0, 3);

        PlayerPrefs.SetInt("PlayerHealth", currentHealth);
        PlayerPrefs.Save();

        Debug.Log("Player Health: " + currentHealth);

        UpdateHealthUI();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateHealthUI()
    {
        if (health1 != null) health1.SetActive(currentHealth >= 1);
        if (health2 != null) health2.SetActive(currentHealth >= 2);
        if (health3 != null) health3.SetActive(currentHealth >= 3);
    }
}
