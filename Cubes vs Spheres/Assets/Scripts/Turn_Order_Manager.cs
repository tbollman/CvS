using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn_Order_Manager : MonoBehaviour
{
    public GameObject[] turnOrder;
    GameObject g;

    public Image[] ImageHolder;
    public Image[] turnOrderUI;
    public Image[] tempUI;

    // Start is called before the first frame update
    void Start()
    {
        for(int j = 0; j < turnOrder.Length - 1; j++)
        {
            for(int i = 0; i < turnOrder.Length - 1; i++)
            {
                if (turnOrder[i].GetComponent<Unit_Stats>().speed < turnOrder[i + 1].GetComponent<Unit_Stats>().speed)
                {
                    g = turnOrder[i + 1];
                    turnOrder[i + 1] = turnOrder[i];
                    turnOrder[i] = g;
                }
            }
        }
        for(int i = 0; i < turnOrder.Length; i++)
        {
            Debug.Log(turnOrder[i].name);
        }

        for(int i = 0; i < turnOrder.Length; i++)
        {
            for(int j = 0; j < ImageHolder.Length; j++)
            {
                if(turnOrder[i].name == ImageHolder[j].name)
                {
                    turnOrderUI[i].sprite = ImageHolder[j].sprite;
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            for (int i = 0; i < turnOrderUI.Length - 1; i++)
            {
                tempUI[i] = turnOrderUI[i + 1]; 
            }
            tempUI[tempUI.Length - 1] = turnOrderUI[0];
            for(int i = 0; i < turnOrderUI.Length; i++)
            {
                turnOrderUI[i].sprite = tempUI[i].sprite;
            }
        }
    }
}
