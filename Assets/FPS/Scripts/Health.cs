﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Photon.Pun;

public class Health : MonoBehaviour
{
    [Tooltip("Maximum amount of health")]
    public float maxHealth = 10f;
    [Tooltip("Health ratio at which the critical health vignette starts appearing")]
    public float criticalHealthRatio = 0.3f;

    public GameObject[] spawnPoints;

    public UnityAction<float, GameObject> onDamaged;
    public UnityAction<float> onHealed;
    public UnityAction onDie;

    public float currentHealth { get; set; }
    public bool invincible { get; set; }
    public bool canPickup() => currentHealth < maxHealth;

    public float getRatio() => currentHealth / maxHealth;
    public bool isCritical() => getRatio() <= criticalHealthRatio;

    bool m_IsDead;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Heal(float healAmount)
    {
        float healthBefore = currentHealth;
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        // call OnHeal action
        float trueHealAmount = currentHealth - healthBefore;
        if (trueHealAmount > 0f && onHealed != null)
        {
            onHealed.Invoke(trueHealAmount);
        }
    }

    public void TakeDamage(float damage, GameObject damageSource)
    {
        print("taking damage ");
        if (invincible)
            return;
         float healthBefore = currentHealth;
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        // call OnDamage action
        float trueDamageAmount = healthBefore - currentHealth;
        if (trueDamageAmount > 0f && onDamaged != null)
        {
            onDamaged.Invoke(trueDamageAmount, damageSource);
        }

        // photon 
        if (currentHealth <= 0) {
          Kill(damageSource);
        }

        HandleDeath();
    }

    public void Kill(GameObject player)
    {
      print("respawning player");
      int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
      player.transform.position = spawnPoints[randomSpawnIndex].transform.position;
      currentHealth = 100f;
    }

    private void HandleDeath()
    {
        // if (m_IsDead)
        //     return;

        // // call OnDie action
        // if (currentHealth <= 0f)
        // {
        //     if (onDie != null)
        //     {
        //         m_IsDead = true;
        //         onDie.Invoke();
        //     }
        // }
    }
}
