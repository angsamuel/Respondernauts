using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission {
    public enum MissionType { Repair, Deliver_Medical_Supplies };
    public MissionType missionType;
    public string location;
    public List<Skill> required_skills;
    public int hostiles_level;
    public string hostile_name;
    public int hostile_equip;


    public Mission()
    {
        int m = Random.Range(0, 2);
        required_skills = new List<Skill>();
        switch (m){
            case 0:
                missionType = MissionType.Repair;
                required_skills.Add(new Skill(Skill.SkillNum.Engineering));
                break;
            case 1:
                missionType = MissionType.Deliver_Medical_Supplies;
                break;
            default:
                break;
        }
        location = "Planet X";
        hostiles_level = 0;
        hostile_equip = 0;
    }
    public string GetObjective()
    {
        switch (missionType)
        {
            case MissionType.Repair:
                return "emergency repairs";
            case MissionType.Deliver_Medical_Supplies:
                return "deliver supplies";
            default:
                return "";
        }
    }
    public string GetHostileDescription()
    {
        switch (hostiles_level)
        {
            case 0:
                return "none expected";
            default:
                return "communication error";
        }
    }
    public string GetHostileEquipmentLevel()
    {
        switch (hostile_equip)
        {
            case 0:
                return "";
            default:
                return "";
        }
    }
}