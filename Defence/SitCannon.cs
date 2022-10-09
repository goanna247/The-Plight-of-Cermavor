using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//y button places sit cannon

public class SitCannon : MonoBehaviour {

  [SerializeField]
  private GameObject bullet; //the bullet object 

  [SerializeField]
  private Transform spawnPoint; //the spawn point where the bullets are shot from

  public float waitBeforeSitCannonShoot = 4f; //time between shots
  public float waitBeforeSitCannonDestroyed = 30f; //cannon will only last 30 seconds then will be self destructed

  [SerializeField]
  private float sitCannonTimer = 0; //keeps track of how long the cannon has been active for

  private GameObject bulletInstance; // gameobject that stores the instaniated bullet

  [SerializeField]
  private static float sitBulletSpeed = 20f; // scalar speed of the bullet when fired 

  private static Vector3 direction = Vector3.forward; //the direction the bullet is going to travel, the forward direction from the object
  Vector3 velocity = sitBulletSpeed * direction; // set the velocity by combining the vector direction and scalar speed values

  [SerializeField]
  private int bulletCount = 0; //how many bullets have been fired

  /// Instantiate a bullet at the spawn point, give it a velocity, and increment the bullet count
  void Fire() {
    bulletInstance = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
    bulletInstance.GetComponent<Rigidbody>().velocity = velocity;
    bulletCount ++;
  }

 /// If the timer is greater than or equal to the time it takes for the bullet to fire, then fire the
 /// bullet, bullets fire every 3 seconds. 10 bullets in total fire. Destroy the cannon after a certain amount of time
  void Update() {
    OVRInput.Update();
    sitCannonTimer += Time.deltaTime;
    if (sitCannonTimer >= 3f && bulletCount == 0) {
      Fire();
    }
    if (sitCannonTimer >= 6f && bulletCount == 1) {
      Fire();
    }
    if (sitCannonTimer >= 9f && bulletCount == 2) {
      Fire();
    }
    if (sitCannonTimer >= 12f && bulletCount == 3) {
      Fire();
    }
    if (sitCannonTimer >= 15f && bulletCount == 4) {
      Fire();
    }
    if (sitCannonTimer >= 18f && bulletCount == 5) {
      Fire();
    }
    if (sitCannonTimer >= 21f && bulletCount == 6) {
      Fire();
    }
    if (sitCannonTimer >= 24f && bulletCount == 7) {
      Fire();
    }
    if (sitCannonTimer >= 27f && bulletCount == 8) {
      Fire();
    }
    if (sitCannonTimer >= 30f && bulletCount == 9) {
      Fire();
    }

    if (sitCannonTimer >= waitBeforeSitCannonDestroyed) {
      Destroy(gameObject);
    }
  }
}