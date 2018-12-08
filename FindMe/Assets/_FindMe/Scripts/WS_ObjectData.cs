using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WS_ObjectData : MonoBehaviour {

    [SerializeField] int id;
    private WS_ObjectInfo objectInfo;


    public WS_ObjectInfo ObjectInfo
    {
        get { return objectInfo; }
        set { objectInfo = value; }
    }

    public int ID
    {
        get { return id; }
    }

}
