using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : TacticsMove
{
    GameObject targetUnit;
    GameObject target;
    HealthManager hM;
    Camera_Manager cM;
    // Start is called before the first frame update
    void Start()
    {
        Init();
        targetUnit = null;
        hM = GetComponent<HealthManager>();
        cM = GameObject.FindGameObjectWithTag("cam").GetComponent<Camera_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hM.dead && turn)
        {
            TurnManager.EndTurn();
        }
        if(!turn) {
            targetUnit = null;
            return;
        }
        if(!moving) {
            FindNearestTarget();
            CheckDistance(Vector3.forward, target);
            CheckDistance(-Vector3.forward, target);
            CheckDistance(Vector3.right, target);
            CheckDistance(-Vector3.right, target);
            if (targetUnit != null)
            {
                StartCoroutine(cM.Attack_Pause(this.gameObject, targetUnit));
                targetUnit.GetComponent<HealthManager>().health--;
                turn = false;
                TurnManager.EndTurn();
            }
                CalculatePath();
                FindSelectableTiles(3);
                actualTargetTile.target = true;
        }
        else
            {
                Move();
            }
       
    }

    void CheckDistance(Vector3 direction, GameObject target)
    {
        Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);
        foreach (Collider item in colliders)
        {
            if (item.gameObject.tag == "Player" && item.gameObject == target)
            {
                targetUnit = item.gameObject;
            }
        }
    }

    void CalculatePath() {
        Tile targetTile = GetTargetTile(target);
        FindPath(targetTile);
    }

    void FindNearestTarget() {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        GameObject nearest = null;
        float distance = Mathf.Infinity;

        foreach(GameObject obj in targets) {
            float d = Vector3.Distance(transform.position, obj.transform.position);
            
            if(d < distance) {
                distance = d;
                nearest = obj;
            }
        }
        target = nearest;
    }
}
