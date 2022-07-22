using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

  public float bulletDestructorTime = 2f; //amount of time before the bullet is destroyed
  public float bulletTimer = 0; //timer that keeps track of how long the bullet has been active for

  public float applyDamage = 10f; //how much damage the bullet applies 


 /* If the bulletTimer is greater than or equal to the bulletDestructorTime, then destroy the gameObject */
  void Update() {
    bulletTimer += Time.deltaTime;

    if (bulletTimer >= bulletDestructorTime) {
      Destroy(gameObject);
    }
  }

/** If the bullet hits something that isn't tagged "Untagged", destroy the bullet. If the bullet hits
  something that is tagged "ENEMY", apply damage to the enemy

  @param Collision The collision that the bullet has hit.
**/ 
  void OnCollisionEnter(Collision other) {
    if (other.transform.tag != "Untagged") {
      Destroy(gameObject);
    }

    if (other.transform.tag == "ENEMY") {
      other.gameObject.GetComponent<HealthScript>().ApplyDamage(applyDamage);
    }
  }
}