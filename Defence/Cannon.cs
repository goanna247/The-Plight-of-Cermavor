using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Cannon : MonoBehaviour {
  [SerializeField]
  private GameObject bullet;
  [SerializeField]
  private Transform spawnPoint;

  public float waitBeforeFireTime = 2f;
  public float waitBeforeDestroyed = 10f;

  private float fireTimer;

  private int bulletCount = 0;
  [SerializeField]
  public static float bulletSpeed = 40f;

  public static Vector3 direction = Vector3.forward;
  Vector3 velocity = bulletSpeed * direction;

  private GameObject bulletInstance;

  void Awake() {
    // MakeBulletInstance();
  }
  

  void Start() {
    bulletCount = 0;

    // Fire();
    // StartCoroutine("FireBullets");
  }

  void MakeBulletInstance() {
  }

  void Update() {
    if (Input.GetKeyUp("a")) {
      //fire bullet
      // MakeBulletInstance();
      bulletInstance =  Instantiate(bullet, spawnPoint.position, Quaternion.identity);
      bulletInstance.GetComponent<Rigidbody>().velocity = velocity;
      bulletCount++;
    }
    // Debug.Log(bulletCount);
    fireTimer += Time.deltaTime;

    // Destroy(bulletInstance, 2);
    // bulletCount--;
  }
}