public class Terrain
{
    public TerrainName terrainName;
    public bool solid;
    public Terrain(bool type, TerrainName name)
    {
        solid = type;
        terrainName = name;
    }
    public override string ToString()
    {
        return solid+"";
    }
}
