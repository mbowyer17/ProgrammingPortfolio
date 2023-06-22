using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WavesManager
{
    
    public abstract float SpawnPositonX();
    public abstract float SpawnPositonY();
    public abstract void WaveMessage();
}

public class SpawnOne : WavesManager
{
    float posX, posY;
    
    public override float SpawnPositonX()
    {
        posX = -7.11f;
     
        return posX;
    }

    public override float SpawnPositonY()
    {
        posY = 4.11f;
        return posY;
    }

    public override void WaveMessage()
    {
        Debug.Log("Spawn1");
    }
}

public class SpawnTwo : WavesManager
{
    float posX, posY;
    public override float SpawnPositonX()
    {
        posX = 7.11f;

        return posX;
    }

    public override float SpawnPositonY()
    {
        posY = 4.11f;

        return posY;
    }

    public override void WaveMessage()
    {
        Debug.Log("Spawn2");
    }
}

public class SpawnThree : WavesManager
{
    float posX, posY;
    public override float SpawnPositonX()
    {
        posX = 7.11f;

        return posX;
    }

    public override float SpawnPositonY()
    {
        posY = -4.11f;

        return posY;
    }

    public override void WaveMessage()
    {
        Debug.Log("Spawn3");
    }
}
public class SpawnFour : WavesManager
{
    float posX, posY;
    public override float SpawnPositonX()
    {
        posX = -7.11f;

        return posX;
    }

    public override float SpawnPositonY()
    {
        posY = -4.11f;

        return posY;
    }

    public override void WaveMessage()
    {
        Debug.Log("Spawn4");
    }
}
public class SpawnFive : WavesManager
{
    float posX, posY;
    public override float SpawnPositonX()
    {
        posX = -8.92f;

        return posX;
    }

    public override float SpawnPositonY()
    {
        posY = -5.83f;

        return posY;
    }

    public override void WaveMessage()
    {
        Debug.Log("Spawn5");
    }
}
public class SpawnSix : WavesManager
{
    float posX, posY;
    public override float SpawnPositonX()
    {
        posX = 8.92f;

        return posX;
    }

    public override float SpawnPositonY()
    {
        posY = 5.83f;

        return posY;
    }

    public override void WaveMessage()
    {
        Debug.Log("Spawn6");
    }
}
public class SpawnBoss : WavesManager
{
    float posX, posY;
    public override float SpawnPositonX()
    {
        posX = 0.02f;

        return posX;
    }

    public override float SpawnPositonY()
    {
        posY = 3.04f;

        return posY;
    }

    public override void WaveMessage()
    {
        Debug.Log("Spawn7");
    }
}