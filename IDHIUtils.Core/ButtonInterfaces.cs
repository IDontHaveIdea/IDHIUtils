//
// Buttons Interfaces
//
using System;

using UnityEngine;


namespace IDHIUtils
{
    // save action button
    public interface IButton
    {
        string Text { get; }
        Rect Position { get; }
        void Process();
    }

    // Background and Foreground color
    public interface IColor
    {
        Color BackgroundColor { get; set; }
        Color ForegroundColor { get; set; }
    }

    // State setting
    public interface IState
    {
        void SetState(byte state);
    }

    // Button with position, process and color
    public interface IColorButton : IButton, IColor
    {
    }

    // Button state added
    public interface IStateButton : IButton, IState
    {
    }

    // Button state and color
    public interface IColorStateButton : IStateButton, IColor
    {
    }

    // What I was thinking working on to many things at once
    // Have to leave them here for a while
    
    // Toggle button has a state method
    [Obsolete("IToggleButton is deprecated use IActionButton")]
    public interface IToggleButton
    {
    }

    // Toggle button adding color
    [Obsolete("IToggleColorButton is deprecated use IColorActionButton")]
    public interface IToggleColorButton
    {
    }

    // Toggle button adding color
    [Obsolete("ColorToggleButton is deprecated use IColorActionButton")]
    public interface IColorToggleButton
    {
    }

    // Button with position and trigger event
    [Obsolete("IButtonEventTrigger is deprecated use IActionButton")]
    public interface IButtonEventTrigger
    {
    }

    // Button with position, trigger event and color
    [Obsolete("IColorButtonEventTrigger is deprecated use IColorActionButton")]
    public interface IColorButtonEventTrigger
    {
    }

    // Button with position and next state method
    [Obsolete("INextStateButton is deprecated use IActionButton")]
    public interface INextStateButton
    {
    }

    [Obsolete("INextStateColorButton is deprecated use IColorActionButton")]
    public interface INextStateColorButton
    {
    }

    // Button with position next state method and color
    [Obsolete("IColorNextStateButton is deprecated use IColorActionButton")]
    public interface IColorNextStateButton
    {
    }

    // Button with position next state method and set state method
    [Obsolete("IStateToggleButton is deprecated use IActionStateButton")]
    public interface IStateToggleButton
    {
    }

    // Button with position next state method and set state method and color
    [Obsolete("IStateToggleColorButton is deprecated use IColorActionStateButton")]
    public interface IStateToggleColorButton
    {
    }

    // Button with position next state method and set state method and color
    [Obsolete("IColorStateToggleButton is deprecated use IColorActionStateButton")]
    public interface IColorStateToggleButton
    {
    }
}
