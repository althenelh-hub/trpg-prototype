using UnityEngine;

public abstract class SkillShape
{
    public abstract Zone changeZone(int size, Extractor extractor, Vector2Int direction);
    public abstract Zone showShape(int size, Extractor extractor);
}
