using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] GameObject explosionVfx;
  [SerializeField] GameObject hitVfx;
  [SerializeField] int hitPoints;
  [SerializeField] int killPoints;
  [SerializeField] int healthPoints;
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
       processEnemyHit();
       killEnemy();
       
    }
    void processEnemyHit()
    {
      hitPoints++;
      GameObject vfx = Instantiate(hitVfx, transform.position, Quaternion.identity);
      vfx.transform.parent = explosionParent.transform;
      score.updateScore(hitPoints);

    }

    void killEnemy()
    {
       if(hitPoints >= healthPoints) {
       score.updateScore(killPoints);
        GameObject vfx = Instantiate(explosionVfx, transform.position, Quaternion.identity);
        vfx.transform.parent = explosionParent.transform;
        Destroy(gameObject);
       }

    }

}
