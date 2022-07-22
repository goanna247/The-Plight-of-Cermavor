using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour {

  [SerializeField]
  private GameObject bullet;//the bullet object

  [SerializeField]
  private Transform spawnPoint; //the bullet spawn object on the cannon (front of the cannon)

  [SerializeField]
  private float turretTimer = 0; //timer that keeps track of how long the current has been active for 
  [SerializeField]
  private float waitBeforeTurretDestroyed = 30f; //how long before the turret is detroyed 

  private GameObject bulletInstance;//object that stores the instance of the bullet being fired

  private static float turretBulletSpeed = 40f; // scalar speed of the bullet when fired 
  private int bulletCount; //variable that keeps track of how many bullets have been fired

  private static Vector3 direction = Vector3.forward;//the direction the bullet is going to travel, the forward direction from the object
  Vector3 velocity = turretBulletSpeed * direction; // set the velocity by combining the vector direction and scalar speed values

/// It instantiates a bullet at the spawnPoint's position, and then sets the velocity of the bullet to
/// the velocity variable.
  void Fire() {
    bulletInstance = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
    bulletInstance.GetComponent<Rigidbody>().velocity = velocity;
  }

/// This function is called when the game starts. It sets the bulletCount variable to 0.
  void Start() {
    bulletCount = 0;
  }

 /// If the timer is greater than or equal to the time it takes to fire a bullet, fire a bullet, and if
 /// the timer is greater than or equal to the time it takes to destroy the turret, destroy the turret.
  void Update() {
    turretTimer += Time.deltaTime;
    gameObject.transform.Rotate(0, 0, 50 * Time.deltaTime);

    // Is there a better way to do this, yes, am i going to do that, no
    if (turretTimer >= 3f && bulletCount == 0) {
      Fire();
    }
    if (turretTimer >= 6f && bulletCount == 1) {
      Fire();
    }
    if (turretTimer >= 9f && bulletCount == 2) {
      Fire();
    }
    if (turretTimer >= 12f && bulletCount == 3) {
      Fire();
    }
    if (turretTimer >= 15f && bulletCount == 4) {
      Fire();
    }
    if (turretTimer >= 18f && bulletCount == 5) {
      Fire();
    }
    if (turretTimer >= 21f && bulletCount == 6) {
      Fire();
    }
    if (turretTimer >= 24f && bulletCount == 7) {
      Fire();
    }
    if (turretTimer >= 27f && bulletCount == 8) {
      Fire();
    }
    if (turretTimer >= 30f && bulletCount == 9) {
      Fire();
    }

    if (turretTimer >= waitBeforeTurretDestroyed) {
      Destroy(gameObject);
    }
  }
}