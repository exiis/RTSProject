using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class init_script : MonoBehaviour
{
    public Transform ground;
    public Transform background;
    
    public List<Transform> ground_set;
    void init_map(){
        for(int z=0; z<32; z++){
                    for(int x=0; x<32; x++){
                        ground_set.Add(Instantiate(ground, new Vector3(x*3.5f, 0, z*3.5f), Quaternion.identity));
                        //ground_set[cnt] = Instantiate(ground, new Vector3(x*3.5f, 0, z*3.5f), Quaternion.identity);
                    }
                }
        for(int i=0; i<3; i++){
            for(int j=0; j<4; j++){
                Instantiate(background, new Vector3(i*50, -1, j*35), Quaternion.identity);
            }
        }
    }

    void init_starting(){

    }

    // Start is called before the first frame update
    void Start()
    {
        init_map();
        init_starting();

        GameObject[] ground_set = GameObject.FindGameObjectsWithTag("ground");
        Debug.Log(ground_set.Length);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}