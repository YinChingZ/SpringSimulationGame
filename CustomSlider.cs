using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomSlider : Slider
{
    public delegate void ValueChangedEvent();
    public event ValueChangedEvent OnCustomValueChanged;

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        OnCustomValueChanged?.Invoke();
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        OnCustomValueChanged?.Invoke();
    }

    public override void OnMove(AxisEventData eventData)
    {
        // Prevent the slider from moving with the left/right arrow keys
        if (eventData.moveDir == MoveDirection.Left || eventData.moveDir == MoveDirection.Right)
        {
            return;
        }
        base.OnMove(eventData);
    }
}   