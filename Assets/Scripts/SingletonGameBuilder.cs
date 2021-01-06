using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGameBuilder
{

    public TeamConfiguration teamLeft;
    public TeamConfiguration teamRight;

    public string area;

    public float aiAutoMoveTime;
    public float aiAutoDefenderTime;
    public float aiAutoThrownTime;

    private SingletonGameBuilder()
    {
        //insert default value
        teamLeft = new TeamConfiguration();
        teamRight = new TeamConfiguration();
        teamLeft.numCharacters = 5;
        teamLeft.teamType = TeamType.ai;
        teamRight.numCharacters = 5;
        teamRight.teamType = TeamType.manual;
        area = "groundBeige_white";
        aiAutoMoveTime = 5f;
        aiAutoDefenderTime = 5f;
        aiAutoThrownTime = 0.5f;
    }

    private static SingletonGameBuilder instance = null;

    public static SingletonGameBuilder Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingletonGameBuilder();
            }
            return instance;
        }
    }

    
    public enum TeamType { ai, manual }


}

public class TeamConfiguration
{
    public int numCharacters;
    public SingletonGameBuilder.TeamType teamType;
}

