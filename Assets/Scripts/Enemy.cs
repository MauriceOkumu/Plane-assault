using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] GameObject explosionVfx;
  [SerializeField] Transform parent;
   Score score;
   void Start() {
      score = FindObjectOfType<Score>();
   }

   void OnParticleCollision(GameObject other) {
       score.updateScore(15);
       killEnemy();
       
    }

    void killEnemy()
    {
        GameObject vfx = Instantiate(explosionVfx, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);

    }
}
