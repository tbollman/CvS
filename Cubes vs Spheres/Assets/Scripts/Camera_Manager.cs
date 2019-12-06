using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    public GameObject cam;
    public GameObject[] unitRotator;
    public ParticleSystem gunflash;
    public AudioSource gunSFX;
    
    public GameObject Enemy;

    public float panSpeed;
    int counter;
    int currentRotation;
    Vector3 origin;
    Vector3 pos;
    bool CameraLock;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        currentRotation = 0;
        CameraLock = false;
    }

    // Update is called once per frame
    void Update() 
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(Attack_Pause(TurnManager.currentUnit, Enemy));
        }


        /************************ PANNING CONTROLS BELOW ********************/

        if (CameraLock == false) //simple bool to lock camera movement during animations
        {
            pos = cam.transform.position; 
            
            
            if (Input.GetKeyDown(KeyCode.E)) //rotates camera to the right
            {
                currentRotation -= 45;
                if (counter == 7)
                {
                    counter = -1;
                }
                counter++;
                cam.transform.rotation = Quaternion.Euler(60, currentRotation, 0);
                for (int i = 0; i < unitRotator.Length; i++)
                {
                    unitRotator[i].transform.rotation = Quaternion.Euler(0, currentRotation, 0);
                }
            }
            if (Input.GetKeyDown(KeyCode.Q)) //rotates camera to the left
            {
                currentRotation += 45;
                if (counter == 0)
                {
                    counter = 8;
                }
                counter--;
                cam.transform.rotation = Quaternion.Euler(60, currentRotation, 0);
                for (int i = 0; i < unitRotator.Length; i++)
                {
                    unitRotator[i].transform.rotation = Quaternion.Euler(0, currentRotation, 0);
                }
            }

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
            {
                if (pos.y <= 7)
                {
                    pos.y += 0.2f;
                    pos.z -= 0.1f;
                }
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                if (pos.y >= 2.5)
                {
                    pos.y -= 0.2f;
                    pos.z += 0.1f;
                }
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

    public IEnumerator Attack_Pause(GameObject unit, GameObject target)
    {
        CameraLock = true;
        origin = cam.transform.position;
        cam.transform.position = unit.transform.position + new Vector3(0, 1, -0.8f);
        unit.transform.GetChild(0).gameObject.SetActive(false);
        unit.transform.GetChild(2).gameObject.SetActive(true);
        gunflash.Play();
        gunSFX.Play();
        yield return new WaitForSeconds(0.5f);
        target.transform.GetChild(0).gameObject.SetActive(false);
        target.transform.GetChild(3).gameObject.SetActive(true);
        cam.transform.position = target.transform.position + new Vector3(0, 1, -0.8f);
        yield return new WaitForSeconds(0.5f);
        unit.transform.GetChild(0).gameObject.SetActive(true);
        target.transform.GetChild(0).gameObject.SetActive(true);
        target.transform.GetChild(3).gameObject.SetActive(false);
        unit.transform.GetChild(2).gameObject.SetActive(false);
        cam.transform.position = origin;
        CameraLock = false;
    }
}
