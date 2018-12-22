using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WS_ObjectData : MonoBehaviour {

    [SerializeField] int id;
    [SerializeField] int _points;
	[SerializeField] int _seconds;
	[SerializeField] protected GameObject _objectIDentifeir;

    public int ID
    {
        get { return id; }
    }

    public int Points
    {
        get
        {
            return _points;
        }
    }

	public int Seconds
	{
		get
		{
			return _seconds;
		}
	}
	public GameObject ObjectIDentifeir
	{
		get
		{
			return _objectIDentifeir;
		}
	}
}
