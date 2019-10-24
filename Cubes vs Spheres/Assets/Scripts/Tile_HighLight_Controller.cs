using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_HighLight_Controller : MonoBehaviour
{
    public Tile_Map_Manager tmm; //Tile_Map_Manager script saved under variable tmm
    public GameObject[] Tiles; //Tile array set equal to New_Tiles
    bool[,] Highlighted_Tile_Array; //Boolean array of highlighted or not
    GameObject[,] Tiles2d; //Placeholder array to convert 1d Tiles[] to Tiles2d[,]
    MeshRenderer[] m; //Holds mesh info for highlight access
    int counter;

    /*TODO - ERROR CHECKING NOT WORKING CORRECTLY, ALSO SHOULD PROBABLY SAVE HIGHLIGHTED SPACE SOME-HOW*/
    void Start()
    {
        counter = 0;
        Tiles = tmm.New_Tiles;
        Tiles2d = new GameObject[4, 4];
        Highlighted_Tile_Array = new bool[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Highlighted_Tile_Array[i, j] = false;
            }
        }
        Highlighted_Tile_Array[0, 0] = true;
    }

    void Update()
    {
        Tiles = tmm.New_Tiles;
        counter = 0;
        for (int i = 0; i < 4; i++) //Converts Tiles into Tiles2d, makes below easier
        {
            for (int j = 0; j < 4; j++)
            {
                Tiles2d[i, j] = Tiles[counter];
                counter++;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (Highlighted_Tile_Array[i, j] == false)
                { 
                    m = Tiles2d[i,j].GetComponentsInChildren<MeshRenderer>();
                    m[1].enabled = false;
                }
                if (Highlighted_Tile_Array[i, j] == true)
                {
                    m = Tiles2d[i, j].GetComponentsInChildren<MeshRenderer>();
                    m[1].enabled = true;
                }
            }
            
        }   
        
        if(Input.GetKeyDown(KeyCode.W))
        {
            Move_Up();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Move_Down();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move_Right();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move_Left();
        }
    }

    void Move_Up()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (Highlighted_Tile_Array[i, j] == true)
                {
                    if (i <= 3) //Attempt at bounds error checking, not working as intended!!!!!!!!
                    { 
                        Highlighted_Tile_Array[i, j] = false;
                        Highlighted_Tile_Array[i+1, j] = true;
                        return;
                    }
                }
            }
        }
    }

    void Move_Down()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (Highlighted_Tile_Array[i, j] == true)
                {
                    if (i >= 0) //Attempt at bounds error checking, not working as intended!!!!!!!!
                    {
                        Highlighted_Tile_Array[i, j] = false;
                        Highlighted_Tile_Array[i - 1, j] = true;
                        return;
                    }
                }
            }
        }
    }

    void Move_Right()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (Highlighted_Tile_Array[i, j] == true)
                {
                    if (j <= 3) //Attempt at bounds error checking, not working as intended!!!!!!!!
                    {
                        Highlighted_Tile_Array[i, j] = false;
                        Highlighted_Tile_Array[i, j + 1] = true;
                        return;
                    }
                }
            }
        }
    }

    void Move_Left()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (Highlighted_Tile_Array[i, j] == true)
                {
                    if (j >= 0) //Attempt at bounds error checking, not working as intended!!!!!!!!
                    {
                        Highlighted_Tile_Array[i, j] = false;
                        Highlighted_Tile_Array[i, j - 1] = true;
                        return;
                    }
                }
            }
        }
    }
}
