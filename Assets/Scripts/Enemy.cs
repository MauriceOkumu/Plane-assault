using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] GameObject explosionVfx;
  [SerializeField] GameObject hitVfx;
  [SerializeField] int hitPoints;
  [SerializeField] int killPoints;
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
      hitPoints++;
      GameObject vfx = Instantiate(hitVfx, transform.position, Quaternion.identity);
      vfx.transform.parent = explosionParent.transform;
       score.updateScore(hitPoints);
       killEnemy();
       
    }

    void killEnemy()
    {
       if(hitPoints >= 6) {
       score.updateScore(killPoints);
        GameObject vfx = Instantiate(explosionVfx, transform.position, Quaternion.identity);
        vfx.transform.parent = explosionParent.transform;
        Destroy(gameObject);
       }

    }
}
