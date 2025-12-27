using System;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private PowerupSO powerup;
    [SerializeField] ParticleSystem powerupParticles;
    PlayerController player;
    SpriteRenderer spriteRenderer;
    float timeleft;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeleft = powerup.GetTime();
    }

    void Update()
    {
        CountdownTimer();
    }

    void CountdownTimer()
    {
        if (spriteRenderer.enabled == false)
        {
            if (timeleft > 0)
            {
                timeleft -= Time.deltaTime;

                if (timeleft <= 0)
                {
                    player.DeactivatePowerup(powerup);
                }
            }
            
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex && spriteRenderer.enabled == true)
        {
            powerupParticles.Play();
            spriteRenderer.enabled = false;
            player.ActivatePowerup(powerup);
        }
    }
}
