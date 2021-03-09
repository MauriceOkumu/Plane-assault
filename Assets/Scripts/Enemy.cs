using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] GameObject explosionVfx;
   GameObject explosionParent;
   Score score;

   void Start() {
      score = FindObjectOfType<Score>();
      explosionParent = GameObject.FindWithTag("Explosions");
      addRigibody();
   }
   void addRigibody() 
   {
      Rigidbody rb = gameObject.AddComponent<Rigidbody>();
      rb.useGravity = false;

   }

   void OnParticleCollision(GameObject other) {
       score.updateScore(15);
       killEnemy();
       
    }

    void killEnemy()
    {
        GameObject vfx = Instantiate(explosionVfx, transform.position, Quaternion.identity);
        vfx.transform.parent = explosionParent.transform;
        Destroy(gameObject);

    }
}
