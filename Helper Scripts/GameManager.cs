using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using static Globals;

//Material gurl

public class GameManager : MonoBehaviour {

  public static GameManager instance; //instance of self

  public float lengthOfDay = 120f; //length of the day cycle in seconds
  public float lengthOfNight = 90f; //length of the night cycle in seconds

  public Material DaySky;
  public Material NightSky;

  [SerializeField]
  private GameObject materialPrefab; //the matian rock prefab

  public Transform[] materialSpawnPoints; //array that stores the spawn points the material can spawn at

  [SerializeField]
  private int materialCount; //variable that keeps track of the amount of materials spawned
  private int initalMaterialCount; //the initial material count

  private float waitBeforeMaterialTime = 2f; //time before materials are spawned

  private Vector3 upwards; //vector that stores the upwards direction

  public int secondsInADay = 120; //the amount of seconds in a day 
  public int secondsInANight = 90; //the amount of seconds in a night. 

  public float dayNightTimer = 0;

  //when the object is awake instaniate the material object 
  void Awake() {
    MakeMaterialInstance();
  }

/// This function is called when the game starts. It sets the initial material count to the material
/// count, spawns the material, starts the coroutine to check if the material should be spawned, and
/// sets the upwards vector to a new vector.
  void Start() {
    initalMaterialCount = materialCount;

    SpawnMaterial();

    StartCoroutine("CheckToSpawnMaterial");

    Globals.IsNight = false;

    upwards = new Vector3(0.0f, 3.0f, 0.0f);
  } 


/// If the instance variable is null, then set it to this
  void MakeMaterialInstance() {
    if (instance == null) {
      instance = this;
    }
  }

  /// We're going to spawn materials at the spawn points in the order they appear in the array
  void SpawnMaterial() {
    int index = 0;

    for (int i=0; i < materialCount; i++) {
      if (index >= materialSpawnPoints.Length) {
        index = 0;
      }
      Instantiate(materialPrefab, materialSpawnPoints[index].position + upwards, Quaternion.identity);
      index++;
    }
    materialCount = 0;
  }

/// Wait for a few seconds, then spawn some materials
  IEnumerator CheckToSpawnMaterial() {
    yield return new WaitForSeconds(waitBeforeMaterialTime);
    SpawnMaterial();
    StartCoroutine("CheckToSpawnMaterial");
  }

/// Stop the coroutine that checks to spawn materials
  public void StopMaterialSpawning() {
    StopCoroutine("CheckToSpawnMaterial");
  }

  void Update() {
    dayNightTimer += Time.deltaTime;
    //game starts in the day phase
    if (Globals.IsNight == false) {
      if (dayNightTimer < secondsInADay) {
        Globals.IsNight = false;
      } else if (dayNightTimer >= secondsInADay) {
        Globals.IsNight = true;
      }
    } else {
      if (dayNightTimer < secondsInANight + secondsInADay) {
        IsNight = true;
      } else if (dayNightTimer >= secondsInANight + secondsInADay) {
        Globals.day ++;
        dayNightTimer = 0;
        IsNight = false;
      }
    }

    if (IsNight) {
      RenderSettings.skybox = NightSky;
    } else {
      RenderSettings.skybox = DaySky;
    }

    enemyCount = Globals.day * 3 + 5;
  }
}