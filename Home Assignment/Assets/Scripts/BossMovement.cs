using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float Movementspeed;
    public float arrivalThreshold = 0.1f; // Adjust this threshold as needed
    private int targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
        MoveToNextPointWithDelay();
    }

    // Update is called once per frame
    void Update()
    {
        // No need for position check in Update anymore
    }

    void MoveToNextPointWithDelay()
    {
        StartCoroutine(MoveToNextPointCoroutine());
    }

    IEnumerator MoveToNextPointCoroutine()
    {

        while (true)
        {
            if (Vector2.Distance(transform.position, patrolPoints[targetPoint].position) < arrivalThreshold)
            {
                IncreasetargetPoint();
                yield return new WaitForSeconds(4f); // Wait for 5 seconds before moving to the next point again
            }

            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[targetPoint].position, Movementspeed * Time.deltaTime);
            yield return null;
        }
    }

    void IncreasetargetPoint()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }


}
