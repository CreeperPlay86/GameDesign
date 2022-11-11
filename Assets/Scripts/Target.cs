using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;

    private AudioSource audioSource;
    [SerializeField] private AudioClip[] dieSounds;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            audioSource.clip = dieSounds[Random.Range(0, dieSounds.Length)];
            audioSource.Play();

            Die();
        }
    }

    void Die()
    {
        

        Destroy(gameObject);
    }
}
