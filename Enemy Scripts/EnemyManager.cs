using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class EnemyManager : MonoBehaviour {
  public static EnemyManager instance; //self

  [SerializeField]
  private GameObject enemyPrefab; //the enemy object

  public Transform[] enemySpawnPoints; //array storing the points in which the enemies will spawn from

  private int enemyCount = Globals.enemyCount; //the amount of enemies currently active

  private int initialEnemyCount; //the initial enemy count
  public float waitBeforeSpawnTime = 2f; //amount of time before the enemies are spawned

  private bool enemiesSpawned = false;

  ///when the object is awake start the inisiation of the enemy objects 
  void Awake() {
    MakeInstance();
  }

  /// We set the initialEnemyCount to the enemyCount, then we call the SpawnEnemies() function, and then
  /// we start the CheckToSpawnEnemies() coroutine.
  void Start() {
    initialEnemyCount = enemyCount;
  }

  void Update() {
    if (enemiesSpawned == false) {
      if (Globals.IsNight) {
        SpawnEnemies();
        StartCoroutine("CheckToSpawnEnemies");
        enemiesSpawned = true;
      }
    }

    if (!Globals.IsNight) {
      enemiesSpawned = false;
      enemyCount = Globals.enemyCount;
    }
  }

/// If the instance variable is null, then set it to this
  void MakeInstance() {
    if (instance == null) {
      instance = this;
    }
  }

  /// We're going to spawn enemies at the spawn points in the order they appear in the array
  void SpawnEnemies() {
    int index = 0;

    for (int i=0; i < enemyCount; i++) {
      if (index >= enemySpawnPoints.Length) {
        index = 0;
      }
      Instantiate(enemyPrefab, enemySpawnPoints[index].position, Quaternion.identity);
      index ++;
    }
    enemyCount = 0;
  }

  /// Wait for a few seconds, then spawn some enemies 
  IEnumerator CheckToSpawnEnemies() {
    yield return new WaitForSeconds(waitBeforeSpawnTime);
    SpawnEnemies();
    StartCoroutine("CheckToSpawnEnemies");
  }

  /// If the enemy count is greater than the initial enemy count, set the enemy count to the initial
  /// enemy count
  public void EnemyDied() {
    enemyCount++;
    if (enemyCount > initialEnemyCount) {
      enemyCount = initialEnemyCount;
    }
  }

/// Stop the coroutine that checks to see if we should spawn enemies
  public void StopSpawning() {
    StopCoroutine("CheckToSpawnEnemies");
  }
}