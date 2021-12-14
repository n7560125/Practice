using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practice : MonoBehaviour
{
    public Transform mLookTarget;
    public Transform mRotateTarget;
    Vector3 velTest = Vector3.zero;
    public GameObject mControllObject;
    public float mRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, mRotateTarget.position, ref velTest, 1.0f);
        //Vector3 currentPos = this.transform.position;
        //Vector3 vDir = mLookTarget.position - currentPos;
        //vDir.y = 0.0f;
        //transform.forward = vDir;
        //transform.LookAt(mLookTarget.position, Vector3.up);
        //Vector3 vRot = new Vector3(0.0f, 1.0f, 0.0f) * Time.deltaTime;
        //transform.Rotate(vRot);
        //transform.rotation = Quaternion.Lerp(transform.rotation, mRotateTarget.rotation, 0.1f);

        //float fh= Input.GetAxis("Horizontal");
        //float fv = Input.GetAxis("Vertical");
        //Debug.Log(fh + ";;;" + fv);
        //Vector3 vMove = mControllObject.transform.forward * fv;
        //vMove += mControllObject.transform.right*fh;
        //vMove *= Time.deltaTime;
  
        //mControllObject.transform.position += vMove;
        float fMh = Input.GetAxis("Mouse X");
        float fMv = Input.GetAxis("Mouse Y");
        Debug.Log(fMh + ";;;" + fMv);

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("col enter " + collision.gameObject.name);
    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * 3.0f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(mControllObject.transform.position, mRadius);
    }
}
