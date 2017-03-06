using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SpectrControl
{
    internal class FilterInput
    {
        public static readonly DependencyProperty InputKindProperty = DependencyProperty.RegisterAttached(
            "InputKind", typeof(InputKind), typeof(FilterInput), new PropertyMetadata(default(InputKind), InputKindChanged));

        private static void InputKindChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var tb = dependencyObject as TextBox;
            var inputKind = (InputKind) e.NewValue;
            if (tb == null) return;
            SetPreviewTextInput(tb, inputKind);
        }

        private static void SetPreviewTextInput(Control control, InputKind inputKind)
        {
            control.PreviewTextInput -= PreviewNumericTextInput;
            control.PreviewTextInput -= PreviewLatinTextInput;
            switch (inputKind)
            {
                case InputKind.Latin:
                    control.PreviewTextInput += PreviewLatinTextInput;
                    break;
                case InputKind.Numeric:
                    control.PreviewTextInput += PreviewNumericTextInput;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private static void PreviewNumericTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[\d]");
        }
        
        private static void PreviewLatinTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "[A-z]");
        }

        public static void SetInputKind(DependencyObject element, InputKind value)
        {
            element.SetValue(InputKindProperty, value);
        }

        public static InputKind GetInputKind(DependencyObject element)
        {
            return (InputKind)element.GetValue(InputKindProperty);
        }
    }

    internal enum InputKind
    {
        Latin, Numeric

    }
}
