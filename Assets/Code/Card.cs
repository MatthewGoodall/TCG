using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class Card
{

    [XmlAttribute("name")]
    public string Name;

    [XmlElement("cost")]
    public int Cost;

    public Card() { }
    
    public Card(string name)
    {
        this.Name = name;
    }
}

[System.Serializable]
public class Monster : Card
{
	[XmlElement("attack")]
	public int Attack;

	[XmlElement("health")]
	public int Health;

	[XmlElement("type")]
	public string Type;

	[XmlElement("ability")]
	public string Ability;

	[XmlElement("desc")]
	public string Desc;

	public Monster(){}

	public Monster(string name, int attack, int health, string type, string ability,
				string desc, int cost)
	{
		this.Name = name;
		this.Attack = attack;
		this.Health = health;
		this.Type = type;
		this.Ability = ability;
		this.Desc = desc;
        this.Cost = cost;

	}
    public enum Abilities
    {
        None,
        BATTLECRY = 1,
        DEATHRATTLE = 2
    }

}

