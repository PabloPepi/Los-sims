using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //funcion del profe
    /*(faltan cosas por copiar)
     * 
     * void MoveCube()
     * {
     * Vector3 pos = Input.mousePosition;
     * Ray rayo = Camera.main.ScreenPointToRay(pos);
     * Raycast hitInfo;
     * cube.setActive(false);
     * if(Physics.Raycast(rayo, out hitInfo) == true)
     * {
     * cube.transform.position = hitInfo.point + vector3.up * cube.transform.localScale.y/2;
     * }
     * cube.SetActive(true);
     * }
     * 
     * 
     * void ReleaseCube()
     * {
     * Debug.Log("Release");
     * cube=null;
     * }
     * 
     * void SelectCube()
     * Debug.Log("Select);
     * Vector3 pos = Input.mousePosition;
     * if(Application.platform == RuntimePlatform.Android)
     * {
     * pos = Input.GetTouch(0).position;
     * }
     * 
     *Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo)== true)
            {

                if (hitInfo.collider.tag.Equals("Cubo"))
                {cube = hitInfo.collider.gameObject;
                }
        }
     */
    // Update is called once per frame
    void Update()
    {
        /*MI FUNCION
         *
        if ((Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            Vector3 pos = Input.mousePosition;

            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo))
            {

                if (hitInfo.collider.tag.Equals("Cubo"))
                {
                    Rigidbody rigidbodyCubo = hitInfo.collider.GetComponent<Rigidbody>();
                    hitInfo.collider.transform.Translate(pos);
                }
        }


        }
    } 
    */
    }
}
