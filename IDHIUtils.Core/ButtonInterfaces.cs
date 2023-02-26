//
// Buttons Interfaces
//
using System;

using UnityEngine;


namespace IDHIUtils
{
    // Button with text
    public interface IButton
    {
        string Text { get; }
    }

    // Background and Foreground color
    public interface IColor
    {
        Color BackgroundColor { get; set; }
        Color ForegroundColor { get; set; }
    }

    // Position Rect
    public interface IPosition
    {
        Rect Position { get; }
    }

    // Process calling
    public interface IProcess
    {
        void Process();
    }

    // State setting
    public interface IState
    {
        void SetState(byte state);
    }

    // Button with text and color definition
    public interface IColorButton : IButton, IColor
    {
    }

    // Button with a position definition
    public interface IPositionButton : IButton, IPosition
    {
    }

    // Button with a position and color
    public interface IColorPositionButton : IPositionButton, IColor
    {
    }

    // Button with position and process
    // Process is meant to be generic not suggesting what is doing
    public interface IActionButton : IPositionButton, IProcess
    {
    }

    // Button with position, process and color
    public interface IColorActionButton : IActionButton, IColor
    {
    }

    // Button with position, process and state
    public interface IActionStateButton : IActionButton, IState
    {
    }

    // Button with position, process, state and color
    public interface IColorActionStateButton : IActionStateButton, IColor
    {
    }

    // What I was thinking working on to many things at once
    // Have to leave them here for a while
    
    // Toggle button has a state method
    [Obsolete("IToggleButton is deprecated use IActionButton")]
    public interface IToggleButton : IButton
    {
        void ToggleState();
    }

    // Toggle button adding color
    [Obsolete("IToggleColorButton is deprecated use IColorActionButton")]
    public interface IToggleColorButton : IColorButton
    {
        void ToggleState();
    }

    // Toggle button adding color
    [Obsolete("ColorToggleButton is deprecated use IColorActionButton")]
    public interface IColorToggleButton : IColorButton
    {
        void ToggleState();
    }

    // Button with position and trigger event
    [Obsolete("IButtonEventTrigger is deprecated use IActionButton")]
    public interface IButtonEventTrigger : IPositionButton
    {
        void TriggerEvent();
    }

    // Button with position, trigger event and color
    [Obsolete("IColorButtonEventTrigger is deprecated use IColorActionButton")]
    public interface IColorButtonEventTrigger : IColorPositionButton
    {
        void TriggerEvent();
    }

    // Button with position and next state method
    [Obsolete("INextStateButton is deprecated use IActionButton")]
    public interface INextStateButton : IPositionButton
    {
        void NextState();
    }

    [Obsolete("INextStateColorButton is deprecated use IColorActionButton")]
    public interface INextStateColorButton : IColorPositionButton
    {
        void NextState();
    }

    // Button with position next state method and color
    [Obsolete("IColorNextStateButton is deprecated use IColorActionButton")]
    public interface IColorNextStateButton : IColorPositionButton
    {
        void NextState();
    }

    // Button with position next state method and set state method
    [Obsolete("IStateToggleButton is deprecated use IActionStateButton")]
    public interface IStateToggleButton : INextStateButton
    {
        void SetState(byte state);
    }

    // Button with position next state method and set state method and color
    [Obsolete("IStateToggleColorButton is deprecated use IColorActionStateButton")]
    public interface IStateToggleColorButton : INextStateColorButton
    {
        void SetState(byte state);
    }

    // Button with position next state method and set state method and color
    [Obsolete("IColorStateToggleButton is deprecated use IColorActionStateButton")]
    public interface IColorStateToggleButton : IColorNextStateButton
    {
        void SetState(byte state);
    }

}
