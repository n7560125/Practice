using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    //singlton;
    static private ResourcesManager mInstance;
    //call Instane to use this class;
    static public ResourcesManager Instance() { return mInstance; }
    
    private void Awake()
    {
        mInstance = this;
    }

    public GameObject LoadGameObject(string sPath)
    {
        GameObject go = null;
        Object o = Resources.Load(sPath);
        if (o == null)
        {
            return null;
        }
        go = Instantiate(o) as GameObject;
        return go;
    }
    public Texture LoadTextureAsset(string sPath)
    {
        Object o = Resources.Load(sPath);
        //Debug.Log(o.GetType());
        return Resources.Load(sPath) as Texture;
    }
    public Object[] LoadAllAsset()
    {
        Object[] oo = Resources.LoadAll("Texture");
        return oo;
    }
}
