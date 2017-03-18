using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ApplicationsManager : MonoBehaviour {

    List<Naut> applicants;
    int index = 0;
    int applicant_min;
    int applicant_max;
    public GameObject naut;
    public Text name_text;
    public Text age_text;
    public Text height_text;
    public Text weight;
    public Text gender_text;
    public Text index_text;
    public Text name_label;
    public Text gender_label;
    public Text age_label;
    public Text height_label;
    public Text weight_label;
    public Text middle_text;
    public Text skills_label;
    public Text skills_text;
    public Dropdown naut_dropdown;

    void Awake()
    {
        applicants = new List<Naut>();
        applicant_min = 3;
        applicant_max = 5;
    }
    // Use this for initialization
    void Start () {
        FillApplicants();
        FillUI();
	}
    public void FillApplicants()
    {
        applicants.Clear();
        int number_to_fill = Random.Range(applicant_min, applicant_max + 1);
        for(int i = 0; i<number_to_fill; i++)
        {
           //GameObject new_naut = Instantiate(naut, new Vector3(0,0,-1000), Quaternion.identity) as GameObject;
           applicants.Add(new Naut());
        }
    }
    public void FillUI()
    {
        if(index > applicants.Count - 1)
        {
            index = applicants.Count - 1;
        }
        if (applicants.Count > 0)
        {
            name_text.text = applicants[index].name;
            age_text.text = applicants[index].age.ToString();
            height_text.text = applicants[index].height.ToString() + " cm";
            weight.text = applicants[index].weight.ToString() + " kg";
            gender_text.text = applicants[index].gender;
            index_text.text = (index + 1).ToString() + " / " + (applicants.Count).ToString();

            skills_text.text = "";
            for(int i = 0; i< applicants[index].skills.Count; i++)
            {
                skills_text.text += applicants[index].skills[i].name + "\n";
            }

        }else
        {
            name_text.text = "";
            age_text.text = "";
            height_text.text = "";
            weight.text = "";
            gender_text.text = "";
            index_text.text = "0 / 0";
            
            name_label.text = "";
            gender_label.text = "";
            age_label.text = "";
            height_label.text = "";
            weight_label.text = "";
            skills_label.text = "";
            skills_text.text = "";
            middle_text.text = "there are no additional applicants";
        }
    }

    public void ViewNext()
    {
        if (applicants.Count > 0)
        {
            index += 1;
            index = index % applicants.Count;
            FillUI();
        }
    }
	public void ViewPrevious()
    {
        if (applicants.Count > 0)
        {
            index -= 1;
            if (index < 0)
            {
                index = applicants.Count - 1;
            }
            FillUI();
        }
    }
    public void ApproveApplication()
    {
        if (applicants.Count > 0)
        {
            //do some flashy fun stuff here
            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.nauts.Add(applicants[index]);
            naut_dropdown.AddOptions(new List<string>() { (applicants[index].name) });
            applicants.RemoveAt(index);
            if (player.nauts.Count == 1)
            {
                SquadManager sm = GameObject.Find("SquadManager").GetComponent<SquadManager>();
                sm.FillUI();
            }
            FillUI();
        }
    }
	// Update is called once per frame
	void Update () {
		
	}


}
