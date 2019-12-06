using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool walkable = true;
    public bool current = false;
    public bool target = false;
    public bool selectable = false;
    public GameObject unitHere;

    public List<Tile> adjacencyList = new List<Tile>();

    //Needed for BFS (Breadth first search)
    public bool visited = false;
    public Tile parent = null;
    public int distance = 0;

    //For A*
    public float f = 0;
    public float g = 0;
    public float h = 0;

    // Start is called before the first frame update
    void Start()
    {
        Random random = new Random();
        string tempTag = this.name;
        int size;
        if(tempTag == "Start") {
            size = 0;
        }
        else {
            size = Random.Range(0,2);
        }
        this.transform.localScale += new Vector3(0,size,0);
        unitHere = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(current) {
            GetComponent<Renderer>().material.color = Color.magenta;
        }
        else if(target) {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if(selectable) {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else {
            GetComponent<Renderer>().material.color = Color.white;
        }
        
    }

    public void Reset() {
        adjacencyList.Clear();
        current = false;
        target = false;
        selectable = false;

        visited = false;
        parent = null;
        distance = 0;

        f = 0;
        g = 0;
        h = 0;
    }

    public void FindNeighbors(float jumpHeight, Tile target) {
        Reset();

        CheckTile(Vector3.forward, jumpHeight, target);
        CheckTile(-Vector3.forward, jumpHeight, target);
        CheckTile(Vector3.right, jumpHeight, target);
        CheckTile(-Vector3.right, jumpHeight, target);
    }
    public void CheckTile(Vector3 direction, float jumpHeight, Tile target) {
        Vector3 halfExtents = new Vector3(0.25f,(1 + jumpHeight)/2.0f,0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

        foreach(Collider item in colliders) {
            Tile tile = item.GetComponent<Tile>();
            if(tile != null && tile.walkable) {
                RaycastHit hit;
                if(!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1) || (tile == target)) {
                    adjacencyList.Add(tile);
                }
            }
        }
    }

    void OnCollisionEnter(Collision coll) {
        unitHere = coll.gameObject;
    }

    void OnCollisionExit(Collision coll) {
        unitHere = null;
    }
}
