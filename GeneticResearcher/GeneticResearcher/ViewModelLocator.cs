using System;
using System.Windows;

namespace GeneticResearcher
{
    public static class ViewModelLocator
    {
        public static bool GetUseDefaultViewModel(DependencyObject obj)
        {
            return (bool) obj.GetValue(UseDefaultViewModelProperty);
        }

        public static void SetUseDefaultViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(UseDefaultViewModelProperty, value);
        }

        public static readonly DependencyProperty UseDefaultViewModelProperty =
            DependencyProperty.RegisterAttached("UseDefaultViewModel", typeof (bool),
                                                typeof (ViewModelLocator),
                                                new PropertyMetadata(false, OnUseDefaultViewModelChanged));
        
        public static void OnUseDefaultViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var viewName = d.GetType().FullName;
            var viewModelName = viewName + "Model";
            var page = (FrameworkElement) d;

            var viewModelType = Type.GetType(viewModelName);
            if(viewModelType == null) return;

            object newInstance = Activator.CreateInstance(viewModelType);
            page.DataContext = newInstance;
        }
    }
}
