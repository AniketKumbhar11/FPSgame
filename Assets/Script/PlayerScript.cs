using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    //public GameObject Arms;
   // public static PlayerScript Player;
    CapsuleCollider col;



    // Use this for initialization
    void Start() {

      //  Arms.SetActive(true);
       // Player = this;
        col = GetComponent<CapsuleCollider>();

    }
	
	// Update is called once per frame
	void Update () {
        
		
	}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("00000");
    }
}
