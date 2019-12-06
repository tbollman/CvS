using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    TacticsMove tM;
    public int health;
    int maxHealth;
    float healthPercent = 1.0f;
    int barLength;
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        tM = GetComponent<TacticsMove>();
        health = 3;
        maxHealth = health;
        barLength = 0;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthPercent = health/maxHealth;
        barLength = (int)((float)maxHealth*healthPercent);
        if (gameObject.name == "Unit_1")
        {
            Debug.Log(gameObject.name + " " + barLength);
        }
        if(health <= 0) {
            dead = true;
            transform.position = new Vector3(0, -100, 0);
        }
    }
}
