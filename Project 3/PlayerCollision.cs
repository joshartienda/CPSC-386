using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private void Start()
    {
        GameManager.instance.onPlay.AddListener(ActivatePlayer);
        FindAnyObjectByType<AudioManager>().Play("BG Music");
    }

    public void ActivatePlayer()
    {
        gameObject.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
            // Set Game Over
            gameObject.SetActive(false);
            GameManager.instance.GameOver();
            FindAnyObjectByType<AudioManager>().Play("Death");
        }
    }

}
