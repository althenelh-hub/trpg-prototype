using UnityEngine;

public class PushUnit : SkillEffects
{
    public override void affect(Unit initiator, Unit target, int compatability, SkillDirection direction) {
        float comparedValue = Mathf.Sqrt(2) / 2;
        Vector2Int pushDirection = target.pos - initiator.pos;
        float pushCos = pushDirection.x / pushDirection.magnitude;
        float pushSin = pushDirection.y / pushDirection.magnitude;
        if(pushCos <= comparedValue && pushSin <= comparedValue && pushSin >= -comparedValue)
        {
            target.pos.x += 1;
        }
        else if (pushSin > comparedValue && pushCos < comparedValue && pushCos >= -comparedValue)
        {
            target.pos.y += 1;
        }
        else if (pushCos <= -comparedValue && pushSin <= comparedValue && pushSin >= -comparedValue)
        {
            target.pos.x -= 1;
        }
        else
        {
            target.pos.y -= 1;
        }

    }
}
