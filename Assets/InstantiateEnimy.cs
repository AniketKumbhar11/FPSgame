using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnimy : MonoBehaviour
{
    public GameObject enemy;
    GameObject prefab;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            prefab = Instantiate(enemy);
            prefab.transform.position = Vector3.MoveTowards(prefab.transform.position, this.transform.position, 2f);
        }


    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    prefab = Instantiate(enemy);
        //    prefab.transform.position = Vector3.MoveTowards(prefab.transform.position, player.transform.position, 20f);
        //}
    }
}
