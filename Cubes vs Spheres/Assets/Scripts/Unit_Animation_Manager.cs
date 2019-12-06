using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Animation_Manager : MonoBehaviour
{
    public GameObject idle;
    public GameObject move;
    public GameObject att;
    public GameObject damaged;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            idle.SetActive(false);
            move.SetActive(true);
            att.SetActive(false);
            damaged.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            idle.SetActive(false);
            move.SetActive(false);
            att.SetActive(true);
            damaged.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            idle.SetActive(false);
            move.SetActive(false);
            att.SetActive(false);
            damaged.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            idle.SetActive(true);
            move.SetActive(false);
            att.SetActive(false);
            damaged.SetActive(false);
        }

    }

}
