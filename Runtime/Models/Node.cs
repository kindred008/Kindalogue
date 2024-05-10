using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    protected string _id;

    protected string _goto;

    public string Id
    {
        get => _id;
    }

    public string Goto
    {
        get => _goto;
        set => _goto = value;
    }
}
