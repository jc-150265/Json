using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;

namespace Json
{
    public partial class MainPage : ContentPage
    {
        private string url;
        /*
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
        */

        public MainPage()
        {
            InitializeComponent();


            url = "https://app.rakuten.co.jp/services/api/BooksBook/Search/20170404?format=json&applicationId=1051637750796067320";

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            var isbncode = new Entry    //EntryでISBNコードを入力
            {
                Placeholder = "ISBNコードを入力してください",
                PlaceholderColor = Color.Gray,
                WidthRequest = 130
            };
            layout.Children.Add(isbncode);

            string requestUrl = url + "&" +isbncode;    //URLにISBNコードを挿入


            var Serch = new Button
            {
                WidthRequest = 60,
                Text = "Serch!",
                TextColor = Color.Red,
            };
            layout.Children.Add(Serch);
            Serch.Clicked += SerchClick;

            Content = layout;
        }

        private void SerchClick(object sender, EventArgs e)
        {
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            /*
            //HTTPアクセス //書き方が古いらしい
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(requestUrl);
            req.Method = "GET";
            HttpWebResponse res = req.GetResponseAsync();
            */

            // HTTPアクセス 
            var req = WebRequest.Create(url);
            var res = req.GetResponseAsync();

            /*
            var res = ResponseAsync(requestUrl);
            var res2 = GetMemoryStream(res);
            */

            // レスポンス(JSON)をオブジェクトに変換 
            Stream s = GetMemoryStream(res);
            StreamReader sr = new StreamReader(s);
            string str = sr.ReadToEnd();


            var deserialized = JsonConvert.DeserializeObject(str);
            foreach (var user in str)
            {
                //Userテーブルの名前列をLabelに書き出します
                layout.Children.Add(new Label { Text = "title: {0}\ntitleKana: {1}" });
            }
            Content = layout;
        }


        private Stream GetMemoryStream(Task<WebResponse> res)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(res));
        }

        //HTTPアクセスメソッド
        public async Task<string> ResponseAsync(String url)
        {
            //返ってきたデータを保存する変数
            String result;

            //HttpClient を作成して Web のデータを読む
            using (var client = new HttpClient())
            {
                result = await client.GetStringAsync(url);
            }
            return result;
        }
        public MemoryStream GetMemoryStream(string text)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(text));
        }
    }

}
