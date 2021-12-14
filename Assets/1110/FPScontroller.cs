using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScontroller : MonoBehaviour
{
    public float fMoveMul;
    public float fControllerSensitivity;
    public GameObject Bullet;
    public GameObject EmitPoint;
    public LayerMask hitlayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform cT = Camera.main.transform;
        //when mousebutton down(fire);
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = new Ray(cT.position, cT.forward);
            RaycastHit rh;
            Vector3 vTarget = cT.position + cT.forward * 100.0f;
            if(Physics.Raycast(r, out rh, 100.0f, hitlayers)) 
            {
                Vector3 vDir = rh.point - cT.position;
                vTarget = rh.point;
                float fD = vDir.magnitude;
                if (fD < 10.0f)
                {
                    vTarget = cT.position + cT.forward * 10.0f;
                }
            }
            Bullet b = Bullet.GetComponent<Bullet>();
            //Bullet.transform.pos ition = EmitPoint.transform.position;
            b.Fire(EmitPoint.transform.position, vTarget);
        }
        float fMX = Input.GetAxis("Mouse X")*fControllerSensitivity;
        float fMY = Input.GetAxis("Mouse Y")*fControllerSensitivity;
        transform.Rotate(0.0f, fMX, 0.0f);
        Camera.main.transform.Rotate(-fMY, 0.0f, 0.0f);

        float fH = Input.GetAxis("Horizontal");
        float fV = Input.GetAxis("Vertical");
        Vector3 vMove = transform.forward * fV;
        vMove += transform.right * fH;
        vMove = vMove* fMoveMul* Time.deltaTime;
        transform.position += vMove;
    }
}
