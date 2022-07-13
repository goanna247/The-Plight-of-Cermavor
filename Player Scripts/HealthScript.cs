using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour {

  private NavMeshAgent navAgent;
  private EnemyController enemyController;

  public float health;
  public float damageBy = 10f;
  public bool isPlayer, isEnemy, isWall, isCannon;
  private bool isDead;

  void Start() {
    if (isPlayer) {
      health = 100f;
    } else if (isEnemy) {
      health = 10f;
    } else if (isCannon) {
      health = 20f;
    } else if (isWall) {
      health = 20f;
    } else {
      health = 20f;
    }
  }

  void Awake() {

  }

  void Update() {
    Debug.Log(health);
    if (isEnemy && health <= 0) {
      EnemyDead();
    }
  }

  public void ApplyDamage(float damage) {
    Debug.Log("DAMAGE");
    
    health = health - damageBy;
  }

  void EnemyDead() {
    Destroy(gameObject);
  }

  void Died() {
    gameObject.SetActive(false);
  }

  void RestartGame() {
    UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
  }

  void TurnOffGameObject() {
    gameObject.SetActive(false);
  }
}