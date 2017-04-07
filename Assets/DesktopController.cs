using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesktopController : MonoBehaviour {
	public GameObject message_panel;
	public GameObject main_panel;
	public Text message_text;
	//application stuffs
	public Player player;
	int application_index;
	public List<Naut> applicants;
	public Text name_text;
	public Text age_text;
	public Text sex_text;
	public Text height_text;
	public Text index_text;

	// Use this for initialization
	void Start () {
		applicants = new List<Naut>();
		for(int i = 0; i<Random.Range(3,6); i++){
			applicants.Add(new Naut());
		}
		application_index = 0;
		FillApplicationUI ();
		message_panel.transform.position = new Vector3 (1000, 1000, 1000);
	}

	public void FillApplicationUI(){
		if (applicants.Count > 0) {
			name_text.text = applicants [application_index].name;
			age_text.text = applicants [application_index].age.ToString ();
			age_text.text += " SOL";
			sex_text.text = applicants [application_index].gender;
			height_text.text = (applicants [application_index].height.ToString ());
			height_text.text += " cm";
			index_text.text = (application_index + 1).ToString () + " / " + applicants.Count.ToString ();
		} else {
			message_panel.transform.position = main_panel.transform.position;
			message_text.text = "there are no applicants";
		}
	}

	public void ViewNextApplication(){
		application_index += 1;
		application_index = application_index % applicants.Count;
		FillApplicationUI ();
	}

	public void ViewPreviousApplication(){
		application_index -= 1;
		if (application_index < 0) {
			application_index = applicants.Count - 1;
		}
		FillApplicationUI ();
	}

	public void AcceptApplicant(){
		player.nauts.Add (applicants [application_index]);
		applicants.RemoveAt (application_index);
		if (application_index > applicants.Count - 1) {
			application_index -= 1;
		}
		FillApplicationUI ();
	}

	public void DenyApplicant(){
		applicants.RemoveAt (application_index);
		if (application_index > applicants.Count - 1) {
			application_index -= 1;
		}
		FillApplicationUI ();
	}


	// Update is called once per frame
	void Update () {
		
	}
}
