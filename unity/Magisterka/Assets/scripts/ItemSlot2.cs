using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemSlot2 : MonoBehaviour, IDropHandler
{
    public GameEq game;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log(GetComponent<RectTransform>().anchoredPosition);
            Vector2 wector = new Vector2(GetComponent<RectTransform>().anchoredPosition.x - 584, GetComponent<RectTransform>().anchoredPosition.y+243);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = wector;
            if (eventData.pointerDrag.GetComponent<ItemInfo>().slot.Equals("eqnow")){
                Destroy(eventData.pointerDrag);
                game.DeleteFromEqNowAddToEq(eventData.pointerDrag.GetComponent<ItemInfo>());
            }
            
        }
    }
}
