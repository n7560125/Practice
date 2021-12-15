using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    private static UIMain mInstance = null;
    public static UIMain Instance() { return mInstance; }

    public Image m_HpBar;

    public GameObject m_PlayerObject;
    public Texture2D m_CursorImage;

    // Start is called before the first frame update
    private void Awake()
    {
        mInstance = this;
    }
    void Start()
    {
        
    }
    public void UpdateHpBar(float fValue)
    {
        Debug.Log("UpdateHpBar " + fValue);
        m_HpBar.fillAmount = fValue;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseEnterImage()
    {
        Cursor.SetCursor(m_CursorImage, Vector2.zero, CursorMode.Auto);
    }
    public void OnMouseExitImage()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    public void ToggleGroupUpdate(ToggleGroup tg)
    {
        Toggle t = tg.GetFirstActiveToggle();
        if (t != null)
        {
            Debug.Log(t.name + ": On");
        }
    }
    public void MyButtonClick(Button b)
    {
        Debug.Log(b.name + ": click");
        //call object method with a value;
        m_PlayerObject.SendMessage("Hit", 10.0f);
       // m_PlayerObject.Hit()
    }
}
