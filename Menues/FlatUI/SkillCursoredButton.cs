using UnityEngine;

public class SkillCursoredButton : CursoredButton
{
    Skill skill;
    UniifiedStorage storage;
    public SkillCursoredButton(Skill skill, UniifiedStorage storage)
    {
        this.skill = skill;
        this.storage = storage;
    }
    public void activate(MainReceiver receiver)
    {
        storage.setSkill(skill);
        receiver.changeInputReceiver(UINames.SkillControl);
        receiver.hideUI(UINames.ChoseSkillMenu);
    }
}
