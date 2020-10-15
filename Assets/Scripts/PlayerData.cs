using System;

[Serializable]
public class PlayerData
{
public int level;
public int hearts;
public float[] position;

    public PlayerData(PlayerController player, int myLevel, int myHearts)
    {
        level = myLevel;
        hearts = myHearts;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
    
}