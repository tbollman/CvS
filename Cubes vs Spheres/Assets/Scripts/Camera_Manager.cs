using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    public GameObject cam;
    //public GameObject centerPoint;

    public float panSpeed;
    int counter;
    int currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        currentRotation = 0;
    }

    // Update is called once per frame
    void Update() 
    {
        Vector3 pos = cam.transform.position;

        //PANNING CONTROLS BELOW

        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentRotation -= 45;
            centerPoint.transform.rotation = Quaternion.Euler(0, currentRotation, 0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentRotation += 45;
            centerPoint.transform.rotation = Quaternion.Euler(0, currentRotation, 0);
        }
          */

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentRotation -= 45;
            if (counter == 7)
            {
                counter = -1;
            }
            counter++;
            cam.transform.rotation = Quaternion.Euler(60, currentRotation, 0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentRotation += 45;
            if (counter == 0)
            {
                counter = 8;
            }
            counter--;
            cam.transform.rotation = Quaternion.Euler(60, currentRotation, 0);
        }
      
        //CAMERA CONTROLS IN RESPECT TO ROTATION BELOW

        if (counter == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                pos.z += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                pos.z -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                pos.x -= panSpeed * Time.deltaTime;
            }
        }
        if (counter == 1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                pos.z += panSpeed * Time.deltaTime;
                pos.x -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                pos.z -= panSpeed * Time.deltaTime;
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                pos.x += panSpeed * Time.deltaTime;
                pos.z += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                pos.x -= panSpeed * Time.deltaTime;
                pos.z -= panSpeed * Time.deltaTime;
            }
        }
        if (counter == 2)
        {
            if (Input.GetKey(KeyCode.W))
            {
                pos.x -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                pos.z += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                pos.z -= panSpeed * Time.deltaTime;
            }
        }
        if (counter == 3)
        {
            if (Input.GetKey(KeyCode.W))
            {
                pos.z -= panSpeed * Time.deltaTime;
                pos.x -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                pos.z += panSpeed * Time.deltaTime;
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                pos.z += panSpeed * Time.deltaTime;
                pos.x -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                pos.z -= panSpeed * Time.deltaTime;
                pos.x += panSpeed * Time.deltaTime;
            }
        }
        if (counter == 4)
        {
            if (Input.GetKey(KeyCode.W))
            {
                pos.z -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                pos.z += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                pos.x -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                pos.x += panSpeed * Time.deltaTime;
            }
        }
        if (counter == 5)
        {
            if (Input.GetKey(KeyCode.W))
            {
                pos.z -= panSpeed * Time.deltaTime;
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                pos.z += panSpeed * Time.deltaTime;
                pos.x -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                pos.x -= panSpeed * Time.deltaTime;
                pos.z -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                pos.x += panSpeed * Time.deltaTime;
                pos.z += panSpeed * Time.deltaTime;
            }
        }
        if (counter == 6)
        {
            if (Input.GetKey(KeyCode.W))
            {
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                pos.x -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                pos.z -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                pos.z += panSpeed * Time.deltaTime;
            }
        }
        if (counter == 7)
        {
            if (Input.GetKey(KeyCode.W))
            {
                pos.z += panSpeed * Time.deltaTime;
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                pos.z -= panSpeed * Time.deltaTime;
                pos.x -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                pos.x += panSpeed * Time.deltaTime;
                pos.z -= panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                pos.x -= panSpeed * Time.deltaTime;
                pos.z += panSpeed * Time.deltaTime;
            }
        }
        cam.transform.position = pos;
       
    }
}
