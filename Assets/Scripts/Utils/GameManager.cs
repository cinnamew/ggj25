using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int lifeForce = 10;

    public void DecrementLifeForce() => lifeForce--;

    public void IncrementLifeForce() => lifeForce++;
}
