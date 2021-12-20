using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    static private ResourcesManager mInstance;
    static public ResourcesManager Instance() { return mInstance; }
    // Start is called before the first frame update
    private void Awake()
    {
        mInstance = this;
    }


}
