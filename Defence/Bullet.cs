using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

  public float bulletDestructorTime = 2f;
  public float bulletTimer = 0;

  public float applyDamage = 10f;

  void Start() {

  }

  void Update() {
    bulletTimer += Time.deltaTime;

    if (bulletTimer >= bulletDestructorTime) {
      Destroy(gameObject);
    }
  }

  void OnCollisionEnter(Collision other) {
    if (other.transform.tag != "Untagged") {
      Destroy(gameObject);
    }

    if (other.transform.tag == "ENEMY") {
      Debug.Log("HIT");
      Debug.Log(other.gameObject);
      other.gameObject.GetComponent<HealthScript>().ApplyDamage(20f);
    }
  }
}