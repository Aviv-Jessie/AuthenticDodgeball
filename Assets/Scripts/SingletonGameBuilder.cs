using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGameBuilder
{

    public TeamConfiguration teamLeft;
    public TeamConfiguration teamRight;

    public string area;

    public string textTutorial;

    private SingletonGameBuilder()
    {
        //insert default value
        teamLeft = new TeamConfiguration();
        teamRight = new TeamConfiguration();
        teamLeft.numCharacters = 1;
        teamLeft.teamType = TeamType.manual;
        teamRight.numCharacters = 1;
        teamRight.teamType = TeamType.ai;
        area = "groundBeige_white";
        textTutorial = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";
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

// Num of characters and team type (AI \ Player)
public class TeamConfiguration
{
    public int numCharacters;
    public SingletonGameBuilder.TeamType teamType;
}

