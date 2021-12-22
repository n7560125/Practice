using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropper : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop " + eventData.pointerDrag.name);

        int inC = transform.childCount;
        if (inC > 0)
        {
            Transform t = transform.GetChild(0);
            // Destroy(t.gameObject); // replace

            Dragger d = eventData.pointerDrag.GetComponent<Dragger>();
            Transform p = d.GetOriginalParent();
            t.SetParent(p);
            t.localPosition = Vector3.zero;
        }

        eventData.pointerDrag.transform.SetParent(this.transform);
        eventData.pointerDrag.transform.localPosition = Vector3.zero;
    }

}
