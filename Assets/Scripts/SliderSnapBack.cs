using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderSnapBack : MonoBehaviour, IEndDragHandler
{
    public float DefualtValue = 0.5f;
    private Slider slider;
    private void Start()
    {
        if (slider == null)
            slider = GetComponent<Slider>();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        slider.value = DefualtValue;
    }
}
