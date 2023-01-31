using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Vehicle
{
    [SerializeField] ParticleSystem explosion;
    [SerializeField] AudioSource explosionSound;
    [SerializeField] GameObject body;

    private void Kill()
    {
        GameManager.Instance.ScoreUp();
        body.SetActive(false);
        explosion.Play();
        explosionSound.Play();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Kill();
        }
        else if(other.gameObject.tag == "Wall")
        {
            body.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
