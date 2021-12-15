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
    public Slider m_AudioOption;

    public Dropdown m_Dp;
    public List<Sprite> m_DpSp;

    // Start is called before the first frame update
    private void Awake()
    {
        mInstance = this;
    }
    void Start()
    {
        m_AudioOption.value = AudioListener.volume;
        
    }
    public void AddInputToCombo(InputField InF)
    {
        Dropdown.OptionData pData = new Dropdown.OptionData();
        pData.text = InF.text;
        pData.image = m_DpSp[2];
        m_Dp.options.Add(pData);
    }
    public void ServerSelected(Dropdown dp)
    {
        int iSelectID = dp.value;
        Debug.Log(dp.options[iSelectID].text);
    }
    public void InitServerCombobox()
    {
        List<Dropdown.OptionData> pList = new List<Dropdown.OptionData>();
        
        Dropdown.OptionData pData = new Dropdown.OptionData();
        pData.text = "Server 1";
        pData.image = m_DpSp[0];
        pList.Add(pData);

        pData = new Dropdown.OptionData();
        pData.text = "Server 2";
        pData.image = m_DpSp[1];
        pList.Add(pData);

        pData = new Dropdown.OptionData();
        pData.text = "Server 3";
        pData.image = m_DpSp[2];
        pList.Add(pData);

        m_Dp.options = pList;
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
    public void SetAudioVolume(Slider s)
    {
        AudioListener.volume = s.value;
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
    }
}
