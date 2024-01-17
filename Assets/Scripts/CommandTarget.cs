using System.Collections.Generic;
using UnityEngine;

public class CommandTarget : MonoBehaviour
{
    public List<string> tags = new List<string>();

    public bool HasTag(string tag)
    {
        return tags.Contains(tag);
    }
}