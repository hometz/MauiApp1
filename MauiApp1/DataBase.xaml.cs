using MauiApp1.Services;
using System.Diagnostics;
using System.Drawing;

namespace MauiApp1;

public partial class DataBase : ContentPage
{
	private readonly IDbService _dbService;
	public DataBase(IDbService dbService)
	{
		InitializeComponent();
		_dbService = dbService;
		_dbService.Init();

        var MuseumList = _dbService.GetAllMuseums();
		foreach (var i in MuseumList)
		{
			Selector.Items.Add(i.Type + " " + i.StartDate + " " + i.Duration);
		}
    }
	
	private void OnSelectedIndexChanged(object sender, EventArgs e) 
	{
		var MuseumList = _dbService.GetAllMuseums();

		foreach (var i in MuseumList)
		{
			if (i.Type + " " + i.StartDate + " " + i.Duration == Selector.SelectedItem as string)
			{
				var ExhibitsList = _dbService.GetMuseumExhibits(i);
				var scrollView = new ScrollView();

				CView.ItemsSource = ExhibitsList;
				CView.ItemTemplate = new DataTemplate(() =>
				{
					var ExhibitName = new Label();
					ExhibitName.SetBinding(Label.TextProperty, "Name");

                    return new Frame
					{
						BorderColor = Colors.White,
						Content = ExhibitName,
						Margin = 20,
						BackgroundColor = Colors.WhiteSmoke
					};
				});

				scrollView.Content = CView;
			}
		}
	}
}