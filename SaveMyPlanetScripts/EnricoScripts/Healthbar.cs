using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // Public Variables regarding health
    [SerializeField] public Slider healthFill;
    [SerializeField] public float currentHealth;
    [SerializeField] public float maxHealth;
    public GameObject youLose;

    private void Update()
    {
        if (currentHealth >= maxHealth)
        {
            Time.timeScale = 0f;
            youLose.SetActive(true);
        }
    }

    public void ChangeHealth (float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthFill.value = currentHealth / maxHealth;
    }
}
