using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JsonObject 
{
    public Item[] boothlist;
}

[System.Serializable]
public class Item 
{
    public string boothNo;
    public string boothName;
    public string boothNameKana;
    public string boothDisplayName;
    public string boothDisplayNameKana;
    public string boothSpawnName;
}
