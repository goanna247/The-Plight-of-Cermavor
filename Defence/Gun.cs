using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using static ControllerManager;

//also has some controller stuff here as well ♡

public class Gun : MonoBehaviour {

  private OVRManager controller; //the OVR manager for the controller
  private InputDevice targetDevice; // the target device controller

  public GameObject leftDebugCube; //the left debug cube in the scene, only for debugging purposes as there is no console when playing 
  public Material blue1; //blue material
  public Material green1; //green material 
  public Material pink1; //pink material 
  public Material orange1; //orange material 

  [SerializeField] 
  private GameObject bullet; //the bullet gameobject, that the gun will fire
  [SerializeField]
  private Transform spawnPoint; //where on the gun object the bullet is fired from (at the front of the gun)

  private float shootTimer; //timer that keeps track of how long the gun has been active 
  private int shootCount; //how many bullets have been shot

  public static float shootSpeed = 40f; //the speed of the bullets when shot

  public static Vector3 shootDirection; //direction the bullets are being shot in
  Vector3 velocity; //Vector object that stores the velocity, to be later initialised 

  private GameObject shootInstance; //gameobject that stores the instance of the bullet created 

  private bool fire = false; //whether the gun is being fired

  /// It sets the shootCount variable to 0.
  void Start() {
    shootCount = 0;
  }

/// If the gun is being used, and the trigger is pressed, then shoot  
  void Update() {
    if (ControllerManager.isGun) {
      if (OVRInput.GetUp(OVRInput.Button.One)) { //TODO @Anna Change this to be the trigger axis not a button &TRIGGER Press??
        fire = true;
      } else {
        fire = false;
      }

      if (fire) {
        Shoot();
      } else {
        leftDebugCube.GetComponent<MeshRenderer>().material = orange1;
      }
    }
  }

/// The function instantiates a bullet prefab at the spawn point, and then adds velocity to the bullet.
  void Shoot() {
    leftDebugCube.GetComponent<MeshRenderer>().material = green1;
    shootInstance = Instantiate(bullet, spawnPoint.position, gameObject.transform.rotation);
    shootInstance.GetComponent<Rigidbody>().velocity = spawnPoint.transform.TransformDirection(Vector3.forward * 10);
    shootCount ++;
  }
}