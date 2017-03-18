using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquadManager : MonoBehaviour {
    int index;
    public Text name_text;
    public Text age_text;
    public Text height_text;
    public Text weight_text;
    public Text gender_text;
    public Text name_label;
    public Text gender_label;
    public Text age_label;
    public Text height_label;
    public Text weight_label;
    public Text middle_text;
    public Text skills_label;
    public GameObject squad_panel;
    public Text skills_text;
    public Dropdown naut_dropdown;
    public GameObject naut_dropdown_label;
    Player player;
    // Use this for initialization
    void Start () {
        index = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
        FillUI();
	}
	
	// Update is called once per frame
	void Update () {
        //SelectNaut();
	}
    public void SelectNaut()
    {
        if (player.nauts.Count > 0)
        {
            for (int i = 0; i < player.nauts.Count; i++)
            {

                if (naut_dropdown_label.GetComponent<Text>().text == player.nauts[i].name)
                {
                    index = i;
                    Debug.Log(index);
                    FillUI();
                }
            }
        }
    }

    public void FillUI()
    {
        if (player.nauts.Count > 0)
        {
            squad_panel.SetActive(true);
            middle_text.text = "";
            skills_label.text = "----------------Skills----------------";
            name_text.text = player.nauts[index].name;
            age_text.text = player.nauts[index].age.ToString();
            height_text.text = player.nauts[index].height.ToString() + " cm";
            weight_text.text = player.nauts[index].weight.ToString() + " kg";
            gender_text.text = player.nauts[index].gender;
            skills_text.text = "";
            for (int i = 0; i < player.nauts[index].skills.Count; i++)
            {
                skills_text.text += player.nauts[index].skills[i].name + "\n";
            }
        }else
        {
            name_text.text = "";
            age_text.text = "";
            height_text.text = "";
            weight_text.text = "";
            gender_text.text = "";
            skills_text.text = "";
            middle_text.text = "you have no squad members";
            squad_panel.SetActive(false);
        }
    }
}
