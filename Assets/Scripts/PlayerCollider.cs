using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    [SerializeField] AudioClip efx;
    AudioSource asource;
    private void Start() {
        asource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) {
        explosion.Play();
        if(!asource.isPlaying) asource.PlayOneShot(efx);
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }
    void ReloadLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
}
