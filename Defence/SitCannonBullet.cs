using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SitCannonBullet : MonoBehaviour {

  [SerializeField]
  private float sitBulletDestructionTime = 4f; //how long before the bullet is destroyed
  private float sitBulletTimer = 0; //timer that keeps track of how long the bullet has been active for

  public float applySitBulletDamage = 10f; //how much damage the bullet applies

/// This function is called every frame and it increases the sitBulletTimer by the amount of time that
/// has passed since the last frame. If the sitBulletTimer is greater than or equal to the
/// sitBulletDestructionTime, then the bullet is destroyed.
  void Update() {
    sitBulletTimer += Time.deltaTime;

    if (sitBulletTimer >= sitBulletDestructionTime) {
      Destroy(gameObject);
    }
  }

/// If the bullet hits an enemy, it will apply damage to the enemy. If the bullet hits anything else, it
/// will destroy itself
/// 
/// @param Collision The collision that the bullet has hit.
  void OnCollisionEnter(Collision other) {
    if (other.transform.tag == "ENEMY") {
      other.gameObject.GetComponent<HealthScript>().ApplyDamage(applySitBulletDamage);
    } else if (other.transform.tag != "Untagged" || other.transform.tag != "WEAPON" ) {
      Destroy(gameObject);
    }
  }
}