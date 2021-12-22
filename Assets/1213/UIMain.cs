using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    private static UIMain mInstance = null;
    public static UIMain Instance() { return mInstance; }

    //  public Image m_HpBar;
    public Object m_FloatingBarPrefab;
    public Object m_FloatingTextPrefab;


    public GameObject m_PlayerObject;
    public Texture2D m_CursorImage;
    public Slider m_AudioOption;

    public Dropdown m_Dp;
    public List<Sprite> m_DpSp;
    private Canvas m_Canvas;
    private RectTransform m_CanvasRectTransform;

    private List<FloatingBar> m_FloatingBarsList;

    private Transform m_DraggerParent = null;
    private Transform m_CurrentDrag = null;

    // Start is called before the first frame update
    private void Awake()
    {
        mInstance = this;
        m_Canvas = GetComponent<Canvas>();
        m_CanvasRectTransform = GetComponent<RectTransform>();
    }

    public Canvas GetCanvas()
    {
        return m_Canvas;
    }
    public RectTransform GetRectTransform()
    {
        return m_CanvasRectTransform;
    }
    void Start()
    {
        // Cursor.visible = false;
        m_FloatingBarsList = new List<FloatingBar>();
        //m_AudioOption.value = AudioListener.volume;
        InitServerCombobox();

        SpawnFloatingBar(m_PlayerObject.transform, 20.0f);
    }

    void SpawnFloatingText(Transform t, float fH, int iNumber)
    {
        Debug.Log("SpawnFloatingText");
        GameObject go = Instantiate(m_FloatingTextPrefab) as GameObject;
        FloatingText ft = go.GetComponent<FloatingText>();
        Vector3 vStart = t.position + Vector3.up * fH;
        ft.SpawnAt(Camera.main, iNumber.ToString(), vStart, 3.0f);
        go.transform.SetParent(this.transform);
    }
    /// <summary>
    /// Spawn Floating Bar(import:Gameobject.transform, Height);
    /// </summary>
    /// <param name="t"></param>
    /// <param name="fH"></param>
    void SpawnFloatingBar(Transform t, float fH)
    {
        Debug.Log("SpawnFloatingBar");
        //Spawn floating bar;
        GameObject go = Instantiate(m_FloatingBarPrefab) as GameObject;
        //Get spawned floating bar's script component;
        FloatingBar fb = go.GetComponent<FloatingBar>();
        //Call func to setup spawned floating bar's variable;
        fb.SetupFollowTarget(t, Camera.main, fH);
        //Add to list;
        m_FloatingBarsList.Add(fb);
        //Set canvas to go's parent;
        go.transform.SetParent(this.transform);
    }
    /// <summary>
    /// Destory Floating bar;
    /// </summary>
    /// <param name="target"></param>
    void DestoryFloatingBar(Transform target)
    {
        int iLen = m_FloatingBarsList.Count;
        for (int i = 0; i < iLen; i++)
        {
            FloatingBar fb = m_FloatingBarsList[i];
            if (fb.GetTarget() == target)
            {
                m_FloatingBarsList.RemoveAt(i);
                Destroy(fb.gameObject);
                return;
            }
        }
    }

    public void ServerSelected(Dropdown dp)
    {
        int iSelectID = dp.value;
        Debug.Log(dp.options[iSelectID].text);
    }

    public void AddInputToCombo(InputField InF)
    {

        Dropdown.OptionData  pData = new Dropdown.OptionData();
        pData.text = InF.text;
        pData.image = m_DpSp[2];
        m_Dp.options.Add(pData);
    }

    public void InitServerCombobox()
    {
        if(m_Dp == null)
        {
            return;
        }
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
       // m_HpBar.fillAmount = fValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //DestoryFloatingBar(m_PlayerObject.transform);
            SpawnFloatingText(m_PlayerObject.transform, 1.0f, -100);
        }
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
        if(t != null)
        {
            Debug.Log(t.name + ": On");
        }
    }

    public void MyButtonClick(Button b)
    {
        Debug.Log(b.name + ": click");
        m_PlayerObject.SendMessage("Hit", 10.0f);
       // m_PlayerObject.Hit()
    }

    public void BeginDragItem(Image m)
    {
        m.transform.position = Input.mousePosition;
        m_DraggerParent = m.transform.parent;
        m.transform.SetParent(m_Canvas.transform);
        m.raycastTarget = false;
        m_CurrentDrag = m.transform;
    }

    public void DragItem(Image m)
    {
        m.transform.position = Input.mousePosition;
    }

    public void EndDragItem(Image m)
    {
        Debug.Log("EndDragItem");
        if (m.transform.parent == this.transform)
        {
            m.transform.SetParent(m_DraggerParent);
            m.transform.localPosition = Vector3.zero;
        }
        m.raycastTarget = true;

        m_DraggerParent = null;
        m_CurrentDrag = null;
    }

    public void DropItem(Image dropTo)
    {
        Debug.Log("DropItem");
        m_CurrentDrag.transform.SetParent(dropTo.transform);
        m_CurrentDrag.transform.localPosition = Vector3.zero;
      
        // m.transform.SetParent(m_DraggerParent);
        // m.transform.localPosition = Vector3.zero;
    }
}
