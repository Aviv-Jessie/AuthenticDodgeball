using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGameBuilder
{

    public TeamConfiguration teamLeft;
    public TeamConfiguration teamRight;

    public string area;

    public SingletonGameBuilder()
    {
        //insert default value
        teamLeft = new TeamConfiguration();
        teamRight = new TeamConfiguration();
        teamLeft.numCharacters = 5;
        teamLeft.teamType = TeamType.manual;
        teamRight.numCharacters = 5;
        teamRight.teamType = TeamType.manual;
        area = "groundBeige_white";
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


}

public class TeamConfiguration
{
    public int numCharacters;
    public TeamType teamType;
}

public enum TeamType { ai, manual }
