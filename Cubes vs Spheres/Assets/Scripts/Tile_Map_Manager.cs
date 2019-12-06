using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Map_Manager : MonoBehaviour
{
    public GameObject[] Tiles; //Array holding types of Tiles
    public GameObject[] Tile_Positions; //Array storing the original position of each placeholder tile
    public GameObject[] New_Tiles; //Array holding newly made tiles
    public GameObject Tile_Holder; //gameoject to hold newly instantiated tiles 

    void Start()
    {
        for(int i = 0; i < Tile_Positions.Length; i++) //Deactivates the tile placeholders
        {
            Tile_Positions[i].SetActive(false);
        }
        BuildMap();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Randomize();
        }
    }
  
    void BuildMap() //Builds new tile map, called at Start
    {
        GameObject g;
        for (int i = 0; i < Tile_Positions.Length; i++)
        {
            g = Tiles[Random.Range(0, 5)];
            New_Tiles[i] = Instantiate(g, Tile_Positions[i].transform.position, Tile_Positions[i].transform.rotation);
            New_Tiles[i].transform.parent = Tile_Holder.transform;
        }
    }

    void Randomize() //Randomize the tile map layout, called by using spacebar
    {
        GameObject g;
        for (int i = 0; i < Tile_Positions.Length; i++)
        {
            g = Tiles[Random.Range(0, 5)];
            Destroy(New_Tiles[i]);
            New_Tiles[i] = Instantiate(g, Tile_Positions[i].transform.position, Tile_Positions[i].transform.rotation);
        }
    }
}
