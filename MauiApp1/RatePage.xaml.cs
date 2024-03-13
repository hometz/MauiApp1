using MauiApp1.Services;

namespace MauiApp1;

public partial class RatePage : ContentPage
{
	private readonly IRateService _rateService;
	public RatePage(IRateService rateService)
	{
		InitializeComponent();
		_rateService = rateService;

		var rateTask = _rateService.GetRates(DateTime.Now);
		List<Rate> rateList = rateTask.Result.ToList();
		Ruble.Text = $"Российский рубль - {rateList[21].Cur_OfficialRate}";
	}
}