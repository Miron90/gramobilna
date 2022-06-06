using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public GameEq game;
    public string tag;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.tag == tag)
        {
            Debug.Log("second");
            Vector2 wector = new Vector2(GetComponent<RectTransform>().anchoredPosition.x-584, GetComponent<RectTransform>().anchoredPosition.y+276);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = wector;
            if (eventData.pointerDrag.GetComponent<ItemInfo>().slot.Equals("eq")){
                Destroy(eventData.pointerDrag);
                game.DeleteFromEqAddToEqnow(eventData.pointerDrag.GetComponent<ItemInfo>());
            }
            

        }
    }
}
