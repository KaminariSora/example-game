using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Health system
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    //Detection system
    public Transform detectionPoint;
    private const float detectionRadius = 0.5f;
    public LayerMask detectionLayer;
    //Damage delay system
    private bool isTakingDamage = false;
    public float damageDelay = 1.0f;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(20);
        }
        if(DetectEnemy() && !isTakingDamage)
        {
            StartCoroutine(TakeDamageWithDelay(10));
        }
    }

    bool DetectEnemy ()
    {
        return Physics2D.OverlapCircle(detectionPoint.position,detectionRadius,detectionLayer);
    }

    private IEnumerator TakeDamageWithDelay(int damage)
    {
        isTakingDamage = true;

        yield return new WaitForSeconds(damageDelay);

        TakeDamage(damage);

        isTakingDamage = false;
    }

    public void TakeDamage(int damage)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("TakeDamage");
        if (currentHealth <= 0)
        {
            Debug.Log("you died");
        }
    }
}
