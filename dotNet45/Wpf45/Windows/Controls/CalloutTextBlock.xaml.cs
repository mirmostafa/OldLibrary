﻿using System;
using System.Windows;
using System.Windows.Media;
using Mohammad.Helpers;
using Mohammad.Wpf.Helpers;

namespace Mohammad.Wpf.Windows.Controls
{
    /// <summary>
    ///     Interaction logic for CalloutTextBlock.xaml
    /// </summary>
    public partial class CalloutTextBlock
    {
        public static readonly DependencyProperty DescriptionProperty = ControlHelper.GetDependencyProperty<string, CalloutTextBlock>("Description",
            onPropertyChanged: (sender, value) =>
            {
                var me = sender.As<CalloutTextBlock>();
                me.DescriptionBlock.Height = value.IsNullOrEmpty() ? 0 : double.NaN;
                me.OnPropertyChanged("Description");
            });

        public string Description { get { return (string) this.GetValue(DescriptionProperty); } set { this.SetValue(DescriptionProperty, value); } }

        public static readonly DependencyProperty HeaderProperty = ControlHelper.GetDependencyProperty<string, CalloutTextBlock>("Header",
            onPropertyChanged: (sender, _) =>
            {
                var me = sender.As<CalloutTextBlock>();
                me.OnPropertyChanged("Header");
                me.OnHeaderChanged(sender);
            });

        public string Header { get { return (string) this.GetValue(HeaderProperty); } set { this.SetValue(HeaderProperty, value); } }

        public static readonly DependencyProperty IsValidProperty = ControlHelper.GetDependencyProperty<bool, CalloutTextBlock>("IsValid",
            (sender, value) =>
            {
                var me = sender.As<CalloutTextBlock>();
                me.LineControl.LineBrush = value ? Brushes.RoyalBlue : Brushes.Red;
            },
            (sender, propName) => sender.As<CalloutTextBlock>().OnPropertyChanged("IsValid"),
            defaultValue: true);

        public bool IsValid { get { return (bool) this.GetValue(IsValidProperty); } set { this.SetValue(IsValidProperty, value); } }
        public CalloutTextBlock() { this.InitializeComponent(); }
        public event EventHandler HeaderChanged;
        protected virtual void OnHeaderChanged(object sender) { this.HeaderChanged?.Invoke(sender, EventArgs.Empty); }
    }
}