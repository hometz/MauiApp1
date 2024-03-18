using MauiApp1.Services;
using System.Diagnostics;

namespace MauiApp1;

public partial class RatePage : ContentPage
{
    //private readonly IRateService _rateService;
    private readonly RateService _rateService = new RateService(new HttpClient());
    public RatePage(/*IRateService rateService*/)
	{
        //_rateService = rateService; 
		InitializeComponent();
        LoadRatesAsync(1, DateTime.Now);
	}

    private async Task LoadRatesAsync(double Multiplyer, DateTime date)
    {
        var rateTask = await _rateService.GetRates(date);
        List<Rate> rateList = rateTask.ToList();
        Ruble.Text = $"Российский рубль: {Multiplyer * (double)(rateList[21].Cur_OfficialRate / 100)}";
        Euro.Text = $"Евро: {Multiplyer * (double)rateList[9].Cur_OfficialRate}";
        USD.Text = $"Доллар США: {Multiplyer * (double)rateList[7].Cur_OfficialRate}";
        Swlnd.Text = $"Швейцарский франк: {Multiplyer * (double)rateList[30].Cur_OfficialRate}";
        China.Text = $"Китайский юань: {Multiplyer * (double)(rateList[16].Cur_OfficialRate / 10)}";
        UK.Text = $"Фунт стерлинг: {Multiplyer * (double)rateList[27].Cur_OfficialRate}";
    }

    private void OnEnterClicked( object sender, EventArgs e )
    {
        DateTime date;
        if (Date.Text == null || Date.Text.Length != 10)
        {
            date = DateTime.Now;
        }
        else date = DateTime.Parse(Date.Text);
        LoadRatesAsync(Convert.ToDouble(Countity.Text), date);
    }

}