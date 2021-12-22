using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingBar : MonoBehaviour
{
    private Transform followTarget;
    private Camera mCamera;
    private Image mImage;
    private float mHeight;
    // Start is called before the first frame update
    void Awake()
    {
        mImage = GetComponent<Image>();
        mHeight = 0.0f;
    }

    public void SetupFollowTarget(Transform t, Camera c, float h)
    {
        followTarget = t;
        mCamera = c;
        mHeight = h;
    }

    public Transform GetTarget()
    {
        return followTarget;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(followTarget == null)
        {
            return;
        }
      
        Vector3 vWPos = followTarget.position + Vector3.up* mHeight;
      //  Debug.Log(mHeight);
        Vector3 scPos = mCamera.WorldToScreenPoint(vWPos);
        if(scPos.z < 0.01f)
        {
            mImage.enabled = false;
        } else
        {
            mImage.enabled = true;
        }
       // Debug.Log(scPos);
        Canvas ca =  UIMain.Instance().GetCanvas();
        RectTransform rt = UIMain.Instance().GetRectTransform();
        RenderMode rm = ca.renderMode;
        if (rm == RenderMode.ScreenSpaceOverlay) {
            mImage.transform.position = scPos;
        } else if(rm == RenderMode.ScreenSpaceCamera)
        {
            Vector2 vOut = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, scPos, mCamera, out vOut);
            mImage.transform.localPosition = new Vector3(vOut.x, vOut.y, 1.0f);
            mImage.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
