using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public List<Texture> mTexAssets;
    public List<Material> mMatAssets;
    // Start is called before the first frame update
    void Start()
    {
        ResourcesManager rm = ResourcesManager.Instance();
        string sPathName = "Cube";
        for (int i = 0; i < 10; i++)
        {
            GameObject go = ResourcesManager.Instance().LoadGameObject(sPathName);
            go.transform.position = new Vector3(i * 2.0f, 1.0f, 0f);
            go.GetComponent<Renderer>().material.mainTexture = rm.LoadTextureAsset("Texture/blood-color");
        }
        Object[] oo = rm.LoadAllAsset();
        foreach(Object o in oo)
        {
            System.Type t = o.GetType();
            if (t == typeof(Texture2D))
            {
                mTexAssets.Add(o as Texture);
            }else if(t==typeof(Material))
            {
                mMatAssets.Add(o as Material);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
