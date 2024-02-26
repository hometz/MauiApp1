using MauiApp1.Services;
using System.Diagnostics;
using System.Drawing;

namespace MauiApp1;

public partial class DataBase : ContentPage
{
	private readonly SqLiteService _dbService = new SqLiteService();
	public DataBase()
	{
		InitializeComponent();
		_dbService.Init();
	}

    [Obsolete]
    private void OnSearchClicked(object sender, EventArgs e)
	{
		var entry = this.FindByName("EntryField") as Entry;
		string FinderStr = entry.Text;
		var MuseumList = _dbService.GetAllMuseums();

		Debug.WriteLine($"List size: {MuseumList.Count()}");

		var menu = this.FindByName("CView") as CollectionView;
		var scrollView = new ScrollView();
		menu.ItemsSource = MuseumList;
		menu.ItemTemplate = new DataTemplate(() =>
		{
			var MuseumId = new Label();
			MuseumId.SetBinding(Label.TextProperty, "Id");

            var MuseumType = new Label();
            MuseumType.SetBinding(Label.TextProperty, "Type");

            var MuseumStartDate = new Label();
            MuseumStartDate.SetBinding(Label.TextProperty, "StartDate");

            var MuseumDuration = new Label();
            MuseumDuration.SetBinding(Label.TextProperty, "Duration");

			return new Frame
			{
				BorderColor = Microsoft.Maui.Graphics.Color.FromHex("#202020"),
				Content = new StackLayout
				{
					Children = { MuseumId, MuseumType, MuseumStartDate, MuseumDuration }
				}
			};
        });
		scrollView.Content = menu;
		
	}
}