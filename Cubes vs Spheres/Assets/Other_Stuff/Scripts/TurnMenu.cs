using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMenu : MonoBehaviour
{
    public PlayerMove pM;
    public bool turn;
    public bool willMove;
    public int move;
    bool attacking;
    public List<GameObject> menuButtons;
    GameObject targetUnit;
    public int range = 2;
    HealthManager hM;
    Camera_Manager cM;
    

    void Start() {
        pM = GetComponent<PlayerMove>();
        turn = pM.turn;
        willMove = false;
        attacking = false;
        targetUnit = null;
        hM = GetComponent<HealthManager>();
        cM = GameObject.FindGameObjectWithTag("cam").GetComponent<Camera_Manager>(); //.GetComponent<Camera_Manager>();
    }
    
    void Update()
    {
        if(hM.dead && turn)
        {
            TurnManager.EndTurn();
        }
        //if(!turn){
            turn = pM.turn;
        //}
        if(turn) {
            pM.GetCurrentTile();
            foreach(GameObject t in menuButtons) {
                t.SetActive(true);
            }
            if(attacking) {
                CheckMouse();
            }
        }
        else {
            foreach(GameObject t in menuButtons) {
                t.SetActive(false);
            }
            willMove = false;
        }

    }

    public void Attack() {
        pM.FindSelectableTiles(2);
        attacking = true;
        willMove = false;
    }

    public void Move() {
        attacking = false;
        willMove = true;
    }

    public void Wait() {
        turn = false;
        pM.turn = false;
        attacking = false;
        targetUnit = null;
        TurnManager.EndTurn();
    }

        void CheckMouse() {
        if(Input.GetMouseButtonUp(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray,out hit)) {
                if(hit.collider.tag == "NPC") {
                    GameObject temp = hit.collider.gameObject;
                    //Debug.Log(temp.name);
                    CheckDistance(Vector3.forward,temp);
                    CheckDistance(-Vector3.forward,temp);
                    CheckDistance(Vector3.right,temp);
                    CheckDistance(-Vector3.right,temp);
                    
                    if (targetUnit != null) {
                        Debug.Log(targetUnit.name);
                        
                        StartCoroutine(cM.Attack_Pause(this.gameObject, targetUnit));
                        targetUnit.GetComponent<HealthManager>().health--;

                        attacking = false;
                        Wait();
                    }
                    else
                    {
                        Debug.Log("NULL");
                    }
                }
            }
        }
    }
    void CheckDistance(Vector3 direction, GameObject target) {
        Vector3 halfExtents = new Vector3(2.0f,2.0f,2.0f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);
        foreach(Collider item in colliders) {
            if (item.gameObject.tag == "NPC" && item.gameObject == target) {
                targetUnit = item.gameObject;
            }
        }
    }
    
}
