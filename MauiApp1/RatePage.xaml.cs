using MauiApp1.Services;

namespace MauiApp1;

public partial class RatePage : ContentPage
{
	private readonly IRateService _rateService;
	public RatePage(IRateService rateService)
	{
		InitializeComponent();
		_rateService = rateService;
	}
}