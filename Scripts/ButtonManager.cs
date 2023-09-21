using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool canScale = false;
    [SerializeField] private Vector2 expectedSize;
    private Vector2 currentSize;


    private void Start()
    {
        currentSize = transform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (canScale)
        {
            LeanTween.scale(gameObject, expectedSize, Time.deltaTime);
        }

        SoundManager.Instance.PlayClip(GameResources.Instance.btnHoverAudioClip, 0.8f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, currentSize, Time.deltaTime);

    }
}
