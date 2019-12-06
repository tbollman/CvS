﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TacticsMove
{
    TurnMenu tM;
    bool willMove;
    int range;
    // Start is called before the first frame update
    void Start()
    {
        Init();
        willMove = false;
        tM = GetComponent<TurnMenu>();
        range = tM.move;
        willMove = tM.willMove;
    }

    // Update is called once per frame
    void Update()
    {
        //if(!willMove) {
            willMove = tM.willMove;
        //}
        Debug.DrawRay(transform.position, transform.forward);
        
        if(!turn || !willMove) {
            return;
        }
        if(!moving) {
            FindSelectableTiles(range);
            CheckMouse();
        }
        else {
            Move();
        }
    }

    void CheckMouse() {
        if(Input.GetMouseButtonUp(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray,out hit)) {
                if(hit.collider.tag == "Tile") {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if(t.selectable) {
                        //todo: move target
                        MoveToTile(t);
                    }
                }
            }
        }
    }
}
