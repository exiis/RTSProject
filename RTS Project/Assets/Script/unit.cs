using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    /* < list info >
    0 : moveSpeed
    1 : attackDamage
    2 : attackSpeed
    3  defense
    4 : sight */
    List<float> stat = new List<float>();

   /* other setting */
    public Transform selectEffect; 
    private CharacterController characterController;
    Vector3 pos, mousePos; //for unit action
    bool unitSelected = false; //for unit state
    public GameObject Plane;

    /* <unit state info>
    1. stop
    2. move
    3. attack
    4. Interaction */
    int unitState = 0;
    void init_pos(){
        mousePos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z)); 
        Debug.Log(pos);
    }

    /* default setting*/
    private void Awake(){
        characterController = GetComponent<CharacterController>();
        for(int i=0; i<5; i++)
            stat.Add(0.0f);
    }

    void getObjPos(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 worldPosition = new Vector3();
        MeshCollider meshCollider = Plane.GetComponent<MeshCollider>();
        if(meshCollider.Raycast(ray, out hit, 1000)){
            worldPosition = hit.point;
        }
        Debug.Log(worldPosition);
        pos = worldPosition;
    }

    void Update() {
        if(Input.GetMouseButton(0)){
            /*
            Debug.Log("new!");
            Instantiate(select, new Vector3(0, 1, 0), select.transform.rotation);
            */
            getObjPos();
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * 5);
        }

        if(Input.GetMouseButton(1)){
            init_pos();
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * 5);
        }
    }
}
