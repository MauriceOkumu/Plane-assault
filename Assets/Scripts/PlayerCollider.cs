using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;

    void OnCollisionEnter(Collision other) {
        explosion.Play();
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }
    void ReloadLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
}
