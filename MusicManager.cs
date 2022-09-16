using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager istance;

    void Awake()
    {
        if(istance == null)
        {
            istance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
