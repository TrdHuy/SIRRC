using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace SIRRC.Utils.Controls
{
    public class ExtendFlyoutItem : FlyoutItem
    {
		public static readonly BindableProperty DataStringProperty =
			 BindableProperty.Create(nameof(DataString), typeof(string), typeof(ExtendFlyoutItem), null);

		public static readonly BindableProperty RenderTransformProperty =
			BindableProperty.Create(nameof(RenderTransform), typeof(Transform), typeof(ExtendFlyoutItem), null,
				propertyChanged: OnTransformPropertyChanged);

		public string DataString
		{
			set { SetValue(DataStringProperty, value); }
			get { return (string)GetValue(DataStringProperty); }
		}

		public Transform RenderTransform
		{
			set { SetValue(RenderTransformProperty, value); }
			get { return (Transform)GetValue(RenderTransformProperty); }
		}

		static void OnTransformPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (oldValue != null)
			{
				(oldValue as Transform).PropertyChanged -= (bindable as ExtendFlyoutItem).OnTransformPropertyChanged;
			}

			if (newValue != null)
			{
				(newValue as Transform).PropertyChanged += (bindable as ExtendFlyoutItem).OnTransformPropertyChanged;
			}
		}


		void OnTransformPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			if (args.PropertyName == Transform.ValueProperty.PropertyName)
			{
				OnPropertyChanged(nameof(RenderTransform));
			}
		}
	}

}
