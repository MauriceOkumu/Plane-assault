using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] GameObject explosionVfx;
  [SerializeField] Transform parent;
  
   void OnParticleCollision(GameObject other) {
        GameObject vfx = Instantiate(explosionVfx, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
