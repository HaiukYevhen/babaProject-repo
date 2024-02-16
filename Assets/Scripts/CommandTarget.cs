using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommandTarget : MonoBehaviour
{
	[Serializable]
	public class TagModel
	{
		public string name;
		public int count = 1;
	}

    public List<TagModel> tags = new List<TagModel>();

    public bool HasTag(string tag)
    {
        return tags.Any(x => x.name == tag);
    }

	public void AddTag(string tag)
	{
		var tagModel = tags.FirstOrDefault(x => x.name == tag);
		
		if (tagModel != null)
		{
			tagModel.count++;
		}
		else
		{
			tags.Add(new TagModel
			{
				name = tag,
				count = 1
			});
		}
	}

	public void RemoveTag(string tag)
	{
		var tagModel = tags.FirstOrDefault(x => x.name == tag);

		if (tagModel != null)
		{
			tagModel.count--;

			if (tagModel.count <= 0)
			{
				tags.Remove(tagModel);
			}
		}
	}
}
