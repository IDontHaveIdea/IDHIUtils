//
// Buttons Interfaces
//
using UnityEngine;


namespace IDHIUtils
{
    public interface IButton
    {
        string Text { get; }
    }

    public interface IColorButton : IButton
    {
        Color BackgroundColor { get; set; }
        Color ForegroundColor { get; set; }
    }

    public interface IToggleButton : IButton
    {
        void ToggleState();
    }

    public interface IToggleColorButton : IColorButton
    {
        void ToggleState();
    }

    public interface IButtonWithPosition : IButton
    {
        Rect Position { get; }
    }

    public interface IColorButtonWithPosition : IColorButton
    {
        Rect Position { get; }
    }

    public interface IButtonEventTrigger : IButtonWithPosition
    {
        void TriggerEvent();
    }

    public interface IColorButtonEventTrigger : IColorButtonWithPosition
    {
        void TriggerEvent();
    }

    public interface INextStateButton : IButtonWithPosition
    {
        void NextState();
    }

    public interface INextStateColorButton : IColorButtonWithPosition
    {
        void NextState();
    }

    public interface IStateToggleButton : INextStateButton
    {
        void SetState(byte state);
    }

    public interface IStateToggleColorButton : INextStateColorButton
    {
        void SetState(byte state);
    }
}
