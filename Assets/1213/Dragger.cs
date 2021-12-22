using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dragger : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Transform m_OriginalParent;
    private Image m_ItemImage;
    // Start is called before the first frame update
    void Start()
    {
        m_OriginalParent = null;
        m_ItemImage = GetComponent<Image>();
    }

    public Transform GetOriginalParent()
    {
        return m_OriginalParent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
        m_OriginalParent = this.transform.parent;
        transform.SetParent(UIMain.Instance().GetCanvas().transform);
        m_ItemImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(transform.parent == UIMain.Instance().GetCanvas().transform)
        {
            transform.SetParent(m_OriginalParent);
            transform.localPosition = Vector3.zero;
        }

        m_ItemImage.raycastTarget = true;
    }




   
}
