using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Praio_Scr : MonoBehaviour {
    void Update()
    {
        transform.LookAt(Camera.main.transform);

        Move();
    }

    private Vector3[] path;

    void BuildPath() {
        var pathParent = transform.Find("Path");

        path = new Vector3[pathParent.childCount];
        for (var i = 0; i < pathParent.childCount; i++) {
            path[i] = pathParent.GetChild(i).position;
        }
    }

    void Start() {
       BuildPath();
    }

    void OnDrawGizmos() {
        BuildPath();
        
        Gizmos.color = Color.magenta;
        foreach (var point in path) {
            Gizmos.DrawSphere(point, 0.1f);
        }

        Gizmos.color = Color.green;
        for (var i = 0; i < path.Length - 1; i++) {
            Gizmos.DrawLine(path[i], path[i + 1]);
        }
    }

    private int target = 0;
    private bool goingReverse = false;

    public float speed = 1;

    private float lastPause;

    public float pauseDuration = 1;

    void Move() {
        if ((transform.position - path[target]).magnitude < 0.05f) {
            if (!goingReverse && target == path.Length - 1) {
                goingReverse = true;
                target--;
            }

            else if (goingReverse && target == 0) {
                goingReverse = false;
                target++;
            }

            else if (goingReverse) {
                target--;
            }

            else {
                target++;
            }

            lastPause = Time.time;
        }

        if (lastPause + pauseDuration > Time.time) return;

        transform.position += (path[target] - transform.position).normalized * speed * Time.deltaTime;
    }
}
