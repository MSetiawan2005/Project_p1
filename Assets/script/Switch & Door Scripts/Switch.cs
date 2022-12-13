using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
	public DoorTrigger[] doorTriggers;
	public bool sticky; //var penentu switch hanya sekali tekan, tidak kembali naik lagi
	private bool down;
	private Animator animator;
	[SerializeField] private List<GameObject> activator;

	void Start () {
		animator = GetComponent<Animator> ();

	}

	void OnTriggerStay2D(Collider2D target)
    {
		if (sticky && down)
		{
			return;
		}
		animator.SetInteger("AnimState", 1); //animasi switch ketekan

        if (!activator.Contains(target.gameObject))
        {
			activator.Add(target.gameObject);
        }
	

		foreach (DoorTrigger trigger in doorTriggers)
		{ //cari semua doortrigger yg didaftarin pada array
			if (trigger != null && !down) //kalo array tidak kosong
            {
				trigger.Toggle(true); //jalankan fungsi toggle pada doortrigger
				down = true; //set boolean true

			}
		}
	}

    void OnTriggerExit2D(Collider2D target){

        if (sticky)
        {
			return;
        }
		activator.Remove(target.gameObject);
			if (activator.Count > 0) //kalau switch sudah ditekan DAN dia sticky
				return; //fungsi tidak dijalankan, alias switch tidak beranimasi naik lagi


			//dibawah ini artinya switch tidak sticky, alias beranimasi naik lagi
			animator.SetInteger("AnimState", 2);
			down = false;

			foreach (DoorTrigger trigger in doorTriggers)
			{ //sama kyk diatas, tapi ini difalse alias naik lagi
				if (trigger != null)
					trigger.Toggle(false);
			}
	}



	void OnDrawGizmos(){ //menggambar garis penanda doortrigger yg bersangkutan
		Gizmos.color = sticky ? Color.blue : Color.green; //kalo biru artinya switch tsb sticky, kalo hijau tidak sticky
		foreach (DoorTrigger trigger in doorTriggers) { //cari semua doortrigger pada array
			if(trigger != null)
				Gizmos.DrawLine(transform.position, trigger.door.transform.position); //gambar garisnya dari posisi si switch
		}
	}
}
