using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToHit : MonoBehaviour
{
    public Camera mCamera;
    public string[] mHitLayers = new string[2];
    public LayerMask mMask;
    public float fSpeed;
    // Start is called before the first frame update
    void Start()
    {
        mHitLayers[0] = "Terrain";
        mHitLayers[1] = "Terrain2";
    }

    // Update is called once per frame
    void Update()
    {
        //when hold mousebutton.
        if (Input.GetMouseButton(0))
        {
            Vector3 mPos = Input.mousePosition;
            //declare a ray from mCamera.position to mPos.position;
            Ray r = mCamera.ScreenPointToRay(mPos);
            //declare a RaycastHit to get information from raycast;
            RaycastHit rh;
            //Raycast(ray, raycasthit, maxdistance, layer);
            if(Physics.Raycast(r, out rh, 1000.0f, mMask))
            {
                //vector from obj.position to target.position;
                Vector3 dir = rh.point - transform.position;
                //y = 0;
                dir.y = 0.0f;
                float dist = dir.magnitude;
                float fMoveAmount = Time.deltaTime * fSpeed * 0.0001f;
                //dead zone;
                if(dist< fMoveAmount)
                {
                    Vector3 oPos = transform.position;
                    oPos.x = rh.point.x;
                    oPos.z = rh.point.z;
                    transform.position = oPos;
                }
                else
                {
                    transform.forward = dir;
                    transform.position += transform.forward * Time.deltaTime * fSpeed;
                }
                Debug.Log("Hit " + rh.collider.name + ":" + rh.point);
            }
        }
    }
}
