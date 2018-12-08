using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WS_WorldManager : MonoBehaviour {

    public event Action<WS_ObjectInfo>  OnObjectSelected;

    Dictionary<int,WS_ObjectData> objectsDataDictionary = new Dictionary<int,WS_ObjectData>();

    bool _controllerClick = false;

    public abstract void Init();


    public Dictionary<int, WS_ObjectData> ObjectsDataDictionary
    {
        get { return objectsDataDictionary; }
    }

    public bool ControllerClick
    {
        set { _controllerClick = value; }
        get { return _controllerClick; }
    }

    public void AddObjectData(WS_ObjectData od)
    {
        objectsDataDictionary.Add(od.ID,od);
    }

    public WS_ObjectData GetObjectDataById(int id)
    {
        WS_ObjectData od = null;
        if (objectsDataDictionary.TryGetValue(id, out od))
        {
            return od;
        }
        return null;
    }

    public WS_ObjectInfo GetObjectInfoById(int id)
    {
        WS_ObjectData od = GetObjectDataById(id);

        if (od == null)
            return null;

        return od.ObjectInfo;
    }

     
}
