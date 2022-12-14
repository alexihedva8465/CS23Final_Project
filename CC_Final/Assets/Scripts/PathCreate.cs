using UnityEngine;

public class PathCreate : MonoBehaviour {

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;
    float elapsedTime;
    private GameHandler GameHandler;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

	// Use this for initialization
	private void Start () {
        GameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	private void Update () {
        elapsedTime = GameHandler.elapsedTime;
     elapsedTime += 1 * Time.deltaTime;
        if (elapsedTime >= 60) {
            Move();
        }

	}

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }

            if (transform.position.x >= 10) {
                waypointIndex = 0;
                transform.position = waypoints[waypointIndex].transform.position;
                Move();
            }
        }
    }
}