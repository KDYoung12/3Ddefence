using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10;
    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = WayPoints.points[0];
        transform.LookAt(target.transform);
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }
    void GetNextWayPoint()
    {
        if(wavepointIndex >= WayPoints.points.Length - 1)
        {
            Debug.Log("°ð µµÂø");
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];
        transform.LookAt(target.transform);
    }
}
