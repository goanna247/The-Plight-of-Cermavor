using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
  public static EnemyManager instance;

  [SerializeField]
  private GameObject enemyPrefab;

  public Transform[] enemySpawnPoints;

  [SerializeField]
  private int enemyCount;

  private int initialEnemyCount;
  public float waitBeforeSpawnTime = 2f;

  void Awake() {
    MakeInstance();
  }

  void Start() {
    initialEnemyCount = enemyCount;

    SpawnEnemies();

    StartCoroutine("CheckToSpawnEnemies");
  }

  void MakeInstance() {
    if (instance == null) {
      instance = this;
    }
  }

  /// <summary>
  /// We're going to spawn enemies at the spawn points in the order they appear in the array
  /// </summary>
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

  /// <summary>
  /// Wait for a few seconds, then spawn some enemies 
  /// </summary>
  IEnumerator CheckToSpawnEnemies() {
    yield return new WaitForSeconds(waitBeforeSpawnTime);
    SpawnEnemies();
    StartCoroutine("CheckToSpawnEnemies");
  }

  /// <summary>
  /// If the enemy count is greater than the initial enemy count, set the enemy count to the initial
  /// enemy count
  /// </summary>
  public void EnemyDied() {
    enemyCount++;
    if (enemyCount > initialEnemyCount) {
      enemyCount = initialEnemyCount;
    }
  }

  public void StopSpawning() {
    StopCoroutine("CheckToSpawnEnemies");
  }
}