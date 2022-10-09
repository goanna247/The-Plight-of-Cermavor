using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Globals;

public class HealthScript : MonoBehaviour {

  private NavMeshAgent navAgent; //the nav agent attached to the object
  private EnemyController enemyController; //the enemy controller script 

  public float health; //the health of the entity 
  public float damageBy = 10f; //damage done
  public bool isPlayer, isEnemy, isWall, isCannon; //booleans for what object the health script is on
  private bool isDead; // whether the object has been killed

/// If the object is a player, set the health to 100. If the object is an enemy, set the health to 10.
/// If the object is a cannon, set the health to 20. If the object is a wall, set the health to 20. If
/// the object is none of the above, set the health to 20.
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

/// If the object is an enemy and its health is less than or equal to zero, then call the EnemyDead()
/// function
  void Update() {
    if (isEnemy && health <= 0) {
      EnemyDead();
    }

    if (!Globals.IsNight) {
      if (isEnemy) {
        EnemyDead();
      }
    }
  }

/// This function takes in a float called damage and subtracts it from the health variable.
/// 
/// @param damage The amount of damage to apply to the health.
  public void ApplyDamage(float damage) {
    Debug.Log("DAMAGE");
    
    health = health - damageBy;
  }

/// When the enemy dies, destroy the game object
  void EnemyDead() {
    if (isEnemy) {
      Globals.totalMoney += 0.1f;
    }
    Destroy(gameObject);
  }

/// When the player dies, set the player object to inactive.
  void Died() {
    gameObject.SetActive(false);
  }

/// Turn off the game object that this script is attached to
  void TurnOffGameObject() {
    gameObject.SetActive(false);
  }
}