using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsCamera : MonoBehaviour
{
    public List<Transform> waypoints;
    public List<GameObject> characters;
    GameObject temp;
    public int currWaypoint = 16;
    Transform curr;

    void Start() {
        curr = transform;
    }

    public void RotateLeft () {
        transform.position = waypoints[++currWaypoint % 4].position;
        transform.Rotate(Vector3.up, 90, Space.Self);
        curr = transform;
        /*foreach(GameObject c in characters) {
            c.transform.rotation = Quaternion.Euler(Vector3.up, curr.rotation.y, Space.Self);
        }*/
    }
    public void RotateRight () {
        transform.position = waypoints[--currWaypoint % 4].position;
        transform.Rotate(Vector3.up, -90, Space.Self);
        curr = transform;
        /*foreach(GameObject c in characters) {
            c.transform.rotation = Quaternion.Euler(Vector3.up, curr.rotation.y, Space.Self);
        }*/
    }
}
