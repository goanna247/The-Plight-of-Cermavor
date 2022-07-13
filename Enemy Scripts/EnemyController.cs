using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

//might add a take damage state later
public enum EnemyState {
  PATROL, //patrol the area during sunset, illicits fear within the player
  ATTACK, //attack a weapon or player 
  COME //move towards the settlement 
}

public class EnemyController : MonoBehaviour {
  
  private NavMeshAgent navAgent;
  public EnemyState enemyState;

  public float walkSpeed = 0.5f;
  public float runSpeed = 4f;

  public float chaseDistance = 7f;
  private float currentChaseDistance;
  public float attackDistance = 1.8f;
  public float chaseAfterAttackDistance = 2f;

  public float patrolRadiusMin = 20f, patrolRadiusMax = 60f;
  public float patrolForThisTime = 15f;
  private float patrolTimer;
  public float patrolSpeed = 2f;

  public float waitBeforeAttack = 2f;
  public float attackTimer;

  private Transform target;

  public GameObject attackPoint;

  public float damage = 2f;
  public float radius = 1f;
  public LayerMask layerMask;

  void Awake() {
    navAgent = GetComponent<NavMeshAgent>();

    target = GameObject.FindWithTag(Tags.TARGET).transform;
  }

  void Start() {
    enemyState = EnemyState.PATROL;
    patrolTimer = patrolForThisTime;
  }

  void Update() {

    if (enemyState == EnemyState.PATROL) {
      Patrol();
    } 

    if (enemyState == EnemyState.COME) {
      Come();
    }

    if (enemyState == EnemyState.ATTACK) {
      Attack();
    }
  }

 /// <summary>
 /// The enemy will patrol around the map until the player is within a certain distance.
 /// </summary>
  void Patrol() {

    //tell nav agent that he can move
    navAgent.isStopped = false;
    navAgent.speed = patrolSpeed;

    patrolTimer += Time.deltaTime;

    if (patrolTimer > patrolForThisTime) {
      SetNewRandomDestination();

      patrolTimer = 0f;
    }

    if (Vector3.Distance(transform.position, target.position) <= chaseDistance) {
      enemyState = EnemyState.COME;
    }
  }

  /// <summary>
  /// The enemy will run towards the target (most likely the player) until it reaches the attack
  /// distance, then it will attack. If the target moves away from the enemy, the enemy will stop
  /// running and go back to patrolling
  /// </summary>
  void Come() {
    navAgent.isStopped= false;
    navAgent.speed = runSpeed;

    navAgent.SetDestination(target.position);

    if (Vector3.Distance(transform.position, target.position) <= attackDistance) {
      enemyState = EnemyState.ATTACK;
      if (chaseDistance != currentChaseDistance) {
        chaseDistance = currentChaseDistance;
      }
    } else if (Vector3.Distance(transform.position, target.position) > chaseDistance) {
      //the target moved away from the enemy (most lilkely platyer)

      //stop running 
      enemyState = EnemyState.PATROL;
      patrolTimer = patrolForThisTime;
      if (chaseDistance != currentChaseDistance) {
        chaseDistance = currentChaseDistance;
      }
    }
  }

  void OnCollisionEnter(Collision other) {
    if (other.transform.tag == "WEAPON") {
      gameObject.SetActive(false); //TODO @Anna add dead state??
    }
  }

  /// <summary>
  /// If the enemy is within attack distance, it will stop moving and attack the player
  /// </summary>
  void Attack() {
    navAgent.velocity = Vector3.zero;
    navAgent.isStopped = true;

    attackTimer += Time.deltaTime;

    if (attackTimer > waitBeforeAttack) {
      attackTimer = 0f;
      //attack here. maybe change object to be red or smth
      // Debug.Log("attack");

      Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);

      if(hits.Length > 0) {
        Debug.Log("HEllo");
        hits[0].gameObject.GetComponent<HealthScript>().ApplyDamage(damage);
        gameObject.SetActive(false);
      }
    }


    if (Vector3.Distance(transform.position, target.position) > attackDistance + chaseAfterAttackDistance) {
      enemyState = EnemyState.COME;
    }
  }


  /// <summary>
  /// We generate a random direction, then we use the NavMesh to find a valid position in that direction
  /// </summary>
  void SetNewRandomDestination() {
    float randRadius = Random.Range(patrolRadiusMin, patrolRadiusMax);
    
    Vector3 randDir = Random.insideUnitSphere * randRadius;
    randDir += transform.position;

    NavMeshHit navHit;

    NavMesh.SamplePosition(randDir, out navHit, randRadius, -1);
    navAgent.SetDestination(navHit.position);
  }

  /// <summary>
  /// sets the attack point active
  /// </summary>
  void TurnOnAttackPoint() {
    attackPoint.SetActive(true);
  }

  /// <summary>
  /// If the attackPoint is active in the hierarchy, then set it to inactive
  /// </summary>
  void TurnOffAttackPoint() {
    if (attackPoint.activeInHierarchy) {
      attackPoint.SetActive(false);
    }
  }

  /* A property that allows us to get and set the enemy state. */
  public EnemyState EnemyState {
    get; 
    set;
  }
}