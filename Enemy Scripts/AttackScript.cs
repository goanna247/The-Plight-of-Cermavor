using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* If there are any objects within the radius of the attack sphere area, apply damage to the first one */
public class AttackScript : MonoBehaviour {
  public float damage = 2f; //the amount of damage applied to the object
  public float radius = 1f; //the radius in which the enemy can attack an object
  public LayerMask layerMask; //the layermask of the enemy

// If there are any objects within the radius of the attack sphere area, apply damage to the first one
	void Update () {
    // Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);

    // if(hits.Length > 0) {
    //   hits[0].gameObject.GetComponent<HealthScript>().ApplyDamage(damage);
    //   gameObject.SetActive(false);
    // }
  }
}