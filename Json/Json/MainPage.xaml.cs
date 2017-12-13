using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace Json
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var p = new person();
            p.Name = "Kamada Yuto";
            p.country = "Japan";
            p.Age = 20;

            var json = JsonConvert.SerializeObject(p);  //---------------------------Json形式に変更
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand,VerticalOptions = LayoutOptions.CenterAndExpand };

            var label = new Label
            {
                Text = $"{json}" //{"Name":"Kamada Yuto","Age":20}
            };
            layout.Children.Add(label);

            var deserialized = JsonConvert.DeserializeObject<person>(json); //---------------------------Json形式から元に戻す
            var label2 = new Label
            {
                Text = $"Name: {deserialized.Name}" //Kamada Yuto
            };
            var label3 = new Label
            {
                Text = $"Age: {deserialized.Age}" //20
            };
            layout.Children.Add(label2);
            layout.Children.Add(label3);

            Content = layout;
        }
    }
}
