using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPersistente : MonoBehaviour
{
    private static AudioPersistente instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
