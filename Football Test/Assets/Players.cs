using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Players
{
    public readonly string positions;

    public readonly string nationality;

    public readonly string ligue;

    public readonly string club;

    public string name;

    public Players (string positions, string nationality, string ligue, string club, string name)
    {
        this.positions = positions;
        this.nationality = nationality;
        this.ligue = ligue;
        this.club = club;
        this.name = name;
    }
}
