using System;
using System.Windows;
using System.Windows.Media;
using Mohammad.Helpers;
using Mohammad.Wpf.Helpers;

namespace Mohammad.Wpf.Windows.Controls
{
    /// <summary>
    ///     Interaction logic for CalloutTextBox.xaml
    /// </summary>
    public partial class CalloutTextBox : IFlickable, IBindable
    {
        public static readonly DependencyProperty DescriptionProperty = ControlHelper.GetDependencyProperty<string, CalloutTextBox>("Description",
            onPropertyChanged: (sender, value) =>
            {
                var me = sender.As<CalloutTextBox>();
                me.DescriptionBlock.Height = value.IsNullOrEmpty() ? 0 : double.NaN;
                me.OnPropertyChanged("Description");
            });

        public string Description { get { return (string) this.GetValue(DescriptionProperty); } set { this.SetValue(DescriptionProperty, value); } }

        public static readonly DependencyProperty HeaderProperty = ControlHelper.GetDependencyProperty<string, CalloutTextBox>("Header",
            onPropertyChanged: (sender, _) => sender.As<CalloutTextBox>().OnPropertyChanged("Header"));

        public string Header { get { return (string) this.GetValue(HeaderProperty); } set { this.SetValue(HeaderProperty, value); } }

        public static readonly DependencyProperty IsValidProperty = ControlHelper.GetDependencyProperty<bool, CalloutTextBox>("IsValid",
            (sender, value) =>
            {
                var me = sender.As<CalloutTextBox>();
                me.LineControl.LineBrush = value ? Brushes.RoyalBlue : Brushes.Red;
            },
            (sender, propName) => sender.As<CalloutTextBox>().OnPropertyChanged("IsValid"),
            defaultValue: true);

        public bool IsValid { get { return (bool) this.GetValue(IsValidProperty); } set { this.SetValue(IsValidProperty, value); } }

        public static readonly DependencyProperty TextProperty = ControlHelper.GetDependencyProperty<string, CalloutTextBox>("Text",
            onPropertyChanged: (sender, _) =>
            {
                var me = sender.As<CalloutTextBox>();
                me.OnPropertyChanged("Text");
                me.OnTextChanged(sender);
            });

        public string Text { get { return (string) this.GetValue(TextProperty); } set { this.SetValue(TextProperty, value); } }
        public CalloutTextBox() { this.InitializeComponent(); }
        public event EventHandler TextChanged;
        protected virtual void OnTextChanged(object sender) { this.TextChanged?.Invoke(sender, EventArgs.Empty); }
        private void CalloutTextBox_OnGotFocus(object sender, RoutedEventArgs e) { this.LabeledTextBox.Focus(); }
        public DependencyProperty BindingFieldProperty => this.LabeledTextBox.BindingFieldProperty;
        public FrameworkElement FlickerTextBlock => this.LabeledTextBox;
    }
}