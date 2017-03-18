using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naut  {
    public string name;
    public int age;
    public int height;
    public int weight;
    public string gender;
    public List<Skill> skills;
	// Use this for initialization
    public Naut () {
        NameWizard nameWizard = GameObject.Find("NameWizard").GetComponent<NameWizard>();
        age = Random.Range(18, 35);
        skills = new List<Skill>();
        int genderChoice = Random.Range(0, 2);
        if(genderChoice < 1)
        {
            gender = "female";
            name = nameWizard.RandomFemaleName() + " " + nameWizard.RandomLastName();
            height = Random.Range(145, 178);
            weight = (int)(45 + 2.3f * ((height - 149) / 2.5));
            weight = (int)(weight * Random.Range(.85f, 1.15f));
        }
        else
        {
            gender = "male";
            name = nameWizard.RandomMaleName() + " " + nameWizard.RandomLastName();
            height = Random.Range(162, 191);
            weight = (int)(50 + 2.3f * ((height - 150) / 2.5));
            weight = (int)(weight * Random.Range(.85f, 1.15f));
        }
        int training = Random.Range(0, 3);
        switch (training)
        {
            case 0:
                skills.Add(new Skill(Skill.SkillNum.Engineering));
                break;
            case 1:
                skills.Add(new Skill(Skill.SkillNum.Programming));
                break;
            case 2:
                skills.Add(new Skill(Skill.SkillNum.Combat_Training));
                break;
            default:
                skills.Add(new Skill(Skill.SkillNum.Combat_Training));
                break;
        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    

	// Update is called once per frame
	void Update () {
		
	}

    int NormalizedRandom(float min, float max)
    {
        float mean = (min + max) / 2;
        float sigma = (max - mean) / 3;
        return (int)Random.Range(mean, sigma);
    }
}
