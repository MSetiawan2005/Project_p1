using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public float closeDelay = .5f;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	void DisableCollider2D(){

		
	}

	void EnableCollider2D(){

		
	}

	public void Open(){
		animator.SetInteger ("AnimState", 1); //animasi pintu terbuka
		GetComponent<BoxCollider2D>().enabled = false; //disable collider agar pintu terbuka bisa dilewati
	}

	public void Close(){
		StartCoroutine (CloseNow ()); //menjalankan coroutine utk delay execution
	}

	private IEnumerator CloseNow(){
		yield return new WaitForSeconds(closeDelay); //fungsi delay
		animator.SetInteger ("AnimState", 2); //animasi pintu tertutup
		GetComponent<BoxCollider2D>().enabled = true; //enable collider agar pintu tertutup tidak bisa dilewati
	}
}
