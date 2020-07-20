using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Waypoint waypoint;
    NavMeshAgent agent;
    public Transform destination;
    public Transform lastSeenPosition;

    public GameController gameController;

    public GameObject shot;
    public Transform shotTransform;

    public float fireRate = 0.1f;
    float nextFire;

    public bool seenTarget;
    public float sightFov = 180f;

    public StateMachine stateMachine = new StateMachine();

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = waypoint.transform.position;

        stateMachine.ChangeState(new State_Patrol(this));
    }
    
    private void OnTriggerStay(Collider other)
    {
        // is it the player?
        if(other.gameObject.tag == "Player"){

            // angle between us and the player
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            
            // reset whether we’ve seen the player
            seenTarget = false;
            
            RaycastHit hit;
            
            // is it less than our field of view
            if (angle < sightFov * 0.5f){
                // if the raycast hits the player we know
                // there is nothing in the way
                // adding transform.up raises up from the floor by 1 unit 
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, GetComponent<SphereCollider>().radius)){
                    if (hit.collider.gameObject.tag == "Player"){
                        // flag that we've seen the player
                        // remember their position
                        seenTarget = true;
                        lastSeenPosition.position = other.gameObject.transform.position;
                    }
                }
            }
        }
    }

    public void FirePlayer(){
        if (Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotTransform.position, shotTransform.rotation);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        
        if (GetComponent<Collider>()!=null)
        {
            Gizmos.DrawWireSphere(transform.position, GetComponent<SphereCollider>().radius);

            if (seenTarget) Gizmos.DrawLine(transform.position, lastSeenPosition.position);
            
            // calculate left fov vector
            Vector3 rightPeripheral;
            rightPeripheral = (Quaternion.AngleAxis(sightFov * 0.5f, Vector3.up) * transform.forward * GetComponent<SphereCollider>().radius);
            // draw lines for the left and right edges of the field of view
        }
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "PlayerShot"){
            gameController.enemyHP -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();    

        // if (!agent.pathPending && agent.remainingDistance < 0.5f){
        //     Waypoint nextWaypoint = waypoint.nextWaypoint; waypoint = nextWaypoint;
        //     agent.destination = waypoint.transform.position;
        // }
    }
}
