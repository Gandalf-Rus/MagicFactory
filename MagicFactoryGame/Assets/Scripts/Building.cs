public class Building : LifeObject
{
    public void Repair(uint points)
    {
        AddHealth(points);
    }
}
