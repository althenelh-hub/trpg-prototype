using System.Collections.Generic;
using UnityEngine;

public class VolumeCursorData 
{
    public VolumeCursorData(ZoneEffectSystem zoneEffectSystem, Extractor extractor)
    {
        this.zoneEffectSystem = zoneEffectSystem;
        this.extractor = extractor;
    }
    public ZoneEffectSystem zoneEffectSystem;
    public Extractor extractor;
}
