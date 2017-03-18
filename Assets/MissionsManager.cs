using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionsManager : MonoBehaviour {
    List<Mission> missions;
    public Text button_one_text;
    public Text button_two_text;
    public Text button_three_text;
    public Text task_text;
    public Text location_text;
    public Text hostiles_text;
    public Text skills_text;


    public Color errorColor;
    public Color acceptColor;
    Player player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        missions = new List<Mission>();
        GenerateMissions();
        FillButtons();
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FillButtons()
    {
        button_one_text.text = missions[0].GetObjective() + " @ " + missions[0].location;
        button_two_text.text = missions[1].GetObjective() + " @ " + missions[1].location;
        button_three_text.text = missions[2].GetObjective() + " @ " + missions[2].location;
    }
    
    public void FillMissionDetails(int i)
    {
        skills_text.text = "";
        task_text.text = missions[i].GetObjective();
        location_text.text = missions[i].location;
        hostiles_text.text = missions[i].GetHostileDescription() + " " + missions[i].GetHostileEquipmentLevel(); 

        for(int s = 0; s<missions[i].required_skills.Count; s++)
        {
            bool hasSkill = false;
            for(int n = 0; n<player.nauts.Count; n++)
            {
                for(int ns = 0; ns<player.nauts[n].skills.Count; ns++)
                {
                    if(missions[i].required_skills[s].name == player.nauts[n].skills[ns].name)
                    {
                        hasSkill = true;
                    }
                }
            }
            if (hasSkill)
            {
                skills_text.text += missions[i].required_skills[s].name + " (present)\n";
            }else
            {
                skills_text.text += missions[i].required_skills[s].name + " (missing)\n";
            }


        }
    }

    void GenerateMissions()
    {
        missions.Clear();
        for(int i = 0; i<3; i++)
        {
            missions.Add(new Mission());
        }
    }
}
