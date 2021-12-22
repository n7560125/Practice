using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    Camera mCamera;
    Vector3 vStartPoint;
    float fLiftTime;
    float fMoveSpeed;
    Text mText;

    // Start is called before the first frame update
    void Awake()
    {
        mText = GetComponent<Text>();
        fMoveSpeed = 0.5f;
        mCamera = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(mCamera == null)
        {
            return;
        }
        vStartPoint = vStartPoint + Vector3.up*fMoveSpeed * Time.deltaTime;

        Vector3 vWPos = vStartPoint;
        //  Debug.Log(mHeight);
        Vector3 scPos = mCamera.WorldToScreenPoint(vWPos);
        if (scPos.z < 0.01f)
        {
            mText.enabled = false;
        }
        else
        {
            mText.enabled = true;
        }
        // Debug.Log(scPos);
        Canvas ca = UIMain.Instance().GetCanvas();
        RectTransform rt = UIMain.Instance().GetRectTransform();
        RenderMode rm = ca.renderMode;
        if (rm == RenderMode.ScreenSpaceOverlay)
        {
            mText.transform.position = scPos;
        }
        else if (rm == RenderMode.ScreenSpaceCamera)
        {
            Vector2 vOut = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, scPos, mCamera, out vOut);
            mText.transform.localPosition = new Vector3(vOut.x, vOut.y, 1.0f);
            mText.transform.localScale = new Vector3(1, 1, 1);
        }

        fLiftTime -= Time.deltaTime;
        if(fLiftTime < 0)
        {
            Destroy(gameObject);
        }
    }

    public void SpawnAt(Camera cam, string str, Vector3 wPos, float fLife)
    {
        mText.text = str;
        vStartPoint = wPos;
        fLiftTime = fLife;
        mCamera = cam;
    }
}
