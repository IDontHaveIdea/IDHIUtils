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
}
