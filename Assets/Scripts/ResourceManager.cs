using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public Sprite Instantiate(string path, Transform parent = null)
    {
        Sprite sprite = Load<Sprite>($"{path}");

        if (sprite == null)
        {
            Debug.Log($"Failed to load sprite : {path}");
            return null;
        }

        return sprite;
    }
}
