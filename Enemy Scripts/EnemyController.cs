using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

/* Creating a new type of variable called EnemyState. It is a list of possible values that the variable
can take. */
public enum EnemyState {
  PATROL, //patrol the area during sunset, illicits fear within the player
  ATTACK, //attack a weapon or player 
  COME //move towards the settlement 
}

public class EnemyController : MonoBehaviour {
  
  private NavMeshAgent navAgent; //the navagent attached to the enemy prefab
  public EnemyState enemyState; //using the Enemy state variable type declared above

  public float walkSpeed = 0.5f; //the walk speed of the enemy
  public float runSpeed = 4f; //the run speed of the enemy 

  public float chaseDistance = 7f; //the chase distance of the enemy
  private float currentChaseDistance; //the current distance the enemy has been chasing for
  public float attackDistance = 1.8f; //the distance before the enemy will attack 
  public float chaseAfterAttackDistance = 2f; // the distance the enemy will run after attacking an object

  public float patrolRadiusMin = 20f, patrolRadiusMax = 60f; // the min and max patrol radius of the enemy 
  public float patrolForThisTime = 15f; //amount of time the enemy will patrol for
  private float patrolTimer; //timer that keeps track of how long the enemy has been active for / has been in a certain state for
  public float patrolSpeed = 2f; //the speed the enemy when patroling 

  public float waitBeforeAttack = 2f; //amount of time the enemy waits before attacking 
  public float attackTimer; //timer that keeps track of the time in the attack state

  private Transform target; //the target of the enemy 

  public GameObject attackPoint; //the attack point of the enemy, where they hit from

  public float damage = 2f; //amount of damage the enemy causes 
  public float radius = 1f; //the radius the enemy can attack in 
  public LayerMask layerMask;

/// The Awake function is called when the script instance is being loaded.
  void Awake() {
    navAgent = GetComponent<NavMeshAgent>();

    target = GameObject.FindWithTag(Tags.PLAYER).transform;
  }

 /// It sets the enemyState to PATROL and sets the patrolTimer to patrolForThisTime.
  void Start() {
    enemyState = EnemyState.PATROL;
    patrolTimer = patrolForThisTime;
  }

/// If the enemy state is patrol, then patrol. If the enemy state is come, then come. If the enemy state
/// is attack, then attack.
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

 /// The enemy will patrol around the map until the player is within a certain distance.
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


  /// The enemy will chase the player until the player is within attack distance, then the enemy will
  /// attack the player. If the player moves away from the enemy, the enemy will stop chasing the player
  /// and go back to patrolling
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

/// If the player hits the enemy with a weapon, the enemy dies
/// 
/// @param Collision The collision object that contains information about the collision.
  void OnCollisionEnter(Collision other) {
    if (other.transform.tag == "WEAPON") {
      gameObject.SetActive(false); //TODO @Anna add dead state??
    }
  }

  /// The enemy is attacking the player, but if the player is too far away, the enemy will chase the
  /// player
  void Attack() {
    navAgent.velocity = Vector3.zero;
    navAgent.isStopped = true;

    attackTimer += Time.deltaTime;

    if (attackTimer > waitBeforeAttack) {
      attackTimer = 0f;
      //attack here. maybe change object to be red or smth
      Debug.Log("attack");

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



/// We generate a random direction, then we use the NavMesh to find a valid position in that direction.
  void SetNewRandomDestination() {
    float randRadius = Random.Range(patrolRadiusMin, patrolRadiusMax);
    
    Vector3 randDir = Random.insideUnitSphere * randRadius;
    randDir += transform.position;

    NavMeshHit navHit;

    NavMesh.SamplePosition(randDir, out navHit, randRadius, -1);
    navAgent.SetDestination(navHit.position);
  }

  /// sets the attack point active
  void TurnOnAttackPoint() {
    attackPoint.SetActive(true);
  }

  /// If the attackPoint is active in the hierarchy, then set it to inactive
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