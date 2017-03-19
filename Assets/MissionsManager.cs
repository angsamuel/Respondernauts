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
    public Text skill_header;
    public GameObject skill_panel;
    public Color errorColor;
    public Color acceptColor;
    Player player;
    public bool can_accept_mission;

    void Awake()
    {
        can_accept_mission = false;
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
    public void AcceptMission()
    {
        if (can_accept_mission)
        {

        }
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
        int skills_had = 0;

        for (int s = 0; s<missions[i].required_skills.Count; s++)
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
                skills_had += 1;
            }else
            {
                skills_text.text += missions[i].required_skills[s].name + " (missing)\n";
            }
        }
        if(skills_had < missions[i].required_skills.Count)
        {
            skill_header.text = "TEAM REQUIRES MORE SKILLS";
            skill_panel.GetComponent<Image>().color = errorColor;

        }else
        {
            skill_header.text = "SKILL REQUIREMENTS SATISFIED";
            skill_panel.GetComponent<Image>().color = acceptColor;
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
