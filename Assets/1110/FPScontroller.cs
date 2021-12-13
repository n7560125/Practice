using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScontroller : MonoBehaviour
{
    public float fMoveMul;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fMX = Input.GetAxis("Mouse X");
        float fMY = Input.GetAxis("Mouse Y");
        transform.Rotate(0.0f, fMX, 0.0f);
        Camera.main.transform.Rotate(fMY, 0.0f, 0.0f);

        float fH = Input.GetAxis("Horizontal");
        float fV = Input.GetAxis("Vertical");
        Vector3 vMove = transform.forward * fV;
        vMove += transform.right * fH;
        vMove = vMove* fMoveMul* Time.deltaTime;
        transform.position += vMove;
    }
}
