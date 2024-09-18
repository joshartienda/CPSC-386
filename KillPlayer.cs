using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour

{
    AudioManager audioManager;
    Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Spikes"))
        {
            audioManager.PlaySFX(audioManager.death);
            Die();
        }
    }

    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = startPos;
    }
}
