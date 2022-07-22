using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cannon : MonoBehaviour {
  [SerializeField]
  private GameObject bullet; //the bullet object
  [SerializeField]
  private Transform spawnPoint; //the bullet spawn object on the cannon (front of the cannon)

  public float waitBeforeFireTime = 2f; //the time in between bullets if consequtively fired
  private int bulletCount = 0; //variable that keeps track of how many bullets have been fired
  [SerializeField]
  public static float bulletSpeed = 40f; // scalar speed of the bullet when fired 

  public static Vector3 direction = Vector3.forward; //the direction the bullet is going to travel, the forward direction from the object
  Vector3 velocity = bulletSpeed * direction; // set the velocity by combining the vector direction and scalar speed values

  private GameObject bulletInstance; //object that stores the instance of the bullet being fired

  /// It sets the bulletCount to 0.
  void Start() {
    bulletCount = 0;
  }

/// If the player presses the "a" key, instantiate a bullet at the spawn point, give it a velocity, and
/// increment the bullet count.
  void Update() {
    if (Input.GetKeyUp("a")) {
      bulletInstance =  Instantiate(bullet, spawnPoint.position, Quaternion.identity);
      bulletInstance.GetComponent<Rigidbody>().velocity = velocity;
      bulletCount++;
    }
    fireTimer += Time.deltaTime;
  }
}