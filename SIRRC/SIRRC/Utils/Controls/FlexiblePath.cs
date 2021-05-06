using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace SIRRC.Utils.Controls
{
    public class FlexiblePath : Path
    {
        public static readonly BindableProperty DataStringProperty =
             BindableProperty.Create(nameof(DataString), typeof(string), typeof(FlexiblePath), null,
                 propertyChanged: OnDataStringPropertyChanged);

        public string DataString
        {
            set { SetValue(DataStringProperty, value); }
            get { return (string)GetValue(DataStringProperty); }
        }

        static void OnDataStringPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var ctrl = bindable as FlexiblePath;
            var convertedGeometry = new PathGeometry();
            PathFigureCollectionConverter.ParseStringToPathFigureCollection(convertedGeometry.Figures, newValue.ToString());
            ctrl.Data = convertedGeometry;
        }
    }
}
