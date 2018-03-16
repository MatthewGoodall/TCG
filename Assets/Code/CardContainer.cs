using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("CardContainer")]
public class CardContainer {
	
	[XmlArray("Cards")]
 	[XmlArrayItem(typeof(Monster)),XmlArrayItem("Card")]
 	public List<Card> allCards = new List<Card>();

	public static CardContainer Load(string path)
 	{
 		var serializer = new XmlSerializer(typeof(CardContainer));
 		using(var stream = new FileStream(path, FileMode.Open))
 		{
 			return serializer.Deserialize(stream) as CardContainer;

 		}
 	}
}
