﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    static Dictionary<string, List<TacticsMove>> units = new Dictionary<string, List<TacticsMove>>();
    static Queue<string> turnKey = new Queue<string>();
    static Queue<TacticsMove> turnTeam = new Queue<TacticsMove>();
    public static GameObject currentUnit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(turnTeam.Count == 0) {
            InitTeamTurnQueue();
        }
        GetCurrentUnit();
        /*if(currentUnit.GetComponent<HealthManager>().dead)
        {
            turnTeam.Dequeue();
            //Destroy(currentUnit);

        }*/
    }

    void GetCurrentUnit()
    {
        foreach(TacticsMove t in turnTeam)
        {
            if(t.turn)
            {
                currentUnit = t.gameObject;
            }
            //Debug.Log(currentUnit.name);
        }
    }

    static void InitTeamTurnQueue() {
        List<TacticsMove> teamList = units[turnKey.Peek()];
        foreach(TacticsMove unit in teamList) {
            turnTeam.Enqueue(unit);
        }
        StartTurn();
    }

    public static void StartTurn() {
        if(turnTeam.Count > 0) {
            turnTeam.Peek().BeginTurn();
        }
    }

    public static void EndTurn() {
        TacticsMove unit = turnTeam.Dequeue();
        unit.EndTurn();

        if(turnTeam.Count > 0) {
            StartTurn();
        }
        else {
            string team = turnKey.Dequeue();
            turnKey.Enqueue(team);
            InitTeamTurnQueue();
        }
    }

    public static void AddUnit(TacticsMove unit) {
        List<TacticsMove> list;
        if(!units.ContainsKey(unit.tag)) {
            list = new List<TacticsMove>();
            units[unit.tag] = list;

            if(!turnKey.Contains(unit.tag)) {
                turnKey.Enqueue(unit.tag);
            }
        }
        else {
            list = units[unit.tag];
        }
        list.Add(unit);
    }

    public static void RemoveUnit(TacticsMove unit) {
            turnTeam.Dequeue();
    }
}
