using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill {
    public enum SkillNum { Engineering, Programming, Combat_Training };
    public SkillNum skillType;
    public string name;
    public string certification;
    public Skill()
    {
        name = "";
        certification = "";
    }
    public Skill(SkillNum sn)
    {
        switch (sn)
        {
            case SkillNum.Engineering:
                name = "Engineering";
                certification = "Federation Engineering Certification";
                break;
            case SkillNum.Programming:
                name = "Programming";
                certification = "Federation Programming Certification";
                break;
            case SkillNum.Combat_Training:
                name = "Combat Training";
                certification = "Federation Standard Combat Training";
                break;
            defualt:
                break;
        }
        skillType = sn;
    }
}
