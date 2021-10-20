using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [Range(0, 15)] [SerializeField] float speed = 1f;

    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // When an enemy gets pulled out of the object pool
    void OnEnable()
    {
        // finds path, goes to the start, and starts the coroutine to follow path
        FindPath();
        MoveToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        // clears path for a new path
        path.Clear();

        // finds object containing the path which is in order
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        // cycles through children and adds component to the path, but if component is not there, it wont add
        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();

            if (waypoint != null)
            {
                path.Add(child.GetComponent<Waypoint>());
            }
        }
    }

    // moves to first index in path
    void MoveToStart()
    {
        transform.position = path[0].transform.position;
    }

    // Coroutine
    IEnumerator FollowPath()
    {
        // starts the loop
        foreach (Waypoint waypoint in path)
        {
            // start is current position, end is position of waypoint (starts on first, then moves froward, which is why there is a one sec delay when starting
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;

            // how much you have actually travelled along the path
            float travelPercent = 0f;

            // looks at next waypoint to reach
            transform.LookAt(endPos);

            // if it hasn't finished traveling ( < x, x is seconds), do this
            while (travelPercent < 1f)
            {
                // adds delta time * speed to travel percent ( 1 sec delta time is always 1 sec, so we use speed variable)
                travelPercent += Time.deltaTime * speed;

                // starts moving to next waypoint using lerp, then waits for frame to finish before repeating
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        // if it makes it to the end, diable object and steal gold
        FinishPath();
    }

    void FinishPath()
    {
        gameObject.SetActive(false);
        enemy.StealHP();
    }
}
