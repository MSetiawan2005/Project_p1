using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerV1 : MonoBehaviour
{
	//ini adalah fungsi door trigger tanpa switch
    public Door door;
    public bool ignoreTrigger;
   void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
			door.Open();
		}
	}

	void OnTriggerExit2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
			door.Close();
		}
	}
}
