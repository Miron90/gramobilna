using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler, IDragHandler,IDropHandler,IPointerUpHandler
{
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 start;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        
        canvasGroup.alpha = 1f;
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        start = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);
    }

    public void OnDrop(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = start;
    }
}
