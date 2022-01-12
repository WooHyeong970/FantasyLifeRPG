using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            
            return instance;
        }
    }

    CameraController _camera = new CameraController();
    ResourceManager _resource = new ResourceManager();

    public static CameraController Camera { get { return Instance._camera; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }


}
