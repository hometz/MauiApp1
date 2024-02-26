using System;
using System.Diagnostics;

namespace MauiApp1;

public partial class PrgsBar : ContentPage
{

    private CancellationTokenSource cancelTokenSource;
    private CancellationToken token;
    private bool realeseStatus = false;
    public PrgsBar()
    {
        InitializeComponent();
        cancelTokenSource = new CancellationTokenSource();
        token = cancelTokenSource.Token;
    }

    private async void OnStartClicked(object sender, EventArgs e)
    {
        Debug.WriteLine($"----------> Main: {Thread.CurrentThread.ManagedThreadId}");
        StartBtn.IsEnabled = false;
        ProgressBar? progress = this.FindByName("Prgs") as ProgressBar;
        Label? label = this.FindByName("Progress") as Label;
        Label? header = this.FindByName("Header") as Label;
        if (!token.IsCancellationRequested && realeseStatus == false)
        {
            double completionPercent = 0;
            double res = 0;
            double A = 0, B = 1;
            double step = 0.00001;
            header.Text = "Running";
            try
            {
                for (double i = A; i <= B; i += step)
                {
                    Debug.WriteLine($"----------> Calc: {Thread.CurrentThread.ManagedThreadId}");

                    await Task.Delay(1);
                    token.ThrowIfCancellationRequested();
                    res += Math.Sin(i) * step;

                    completionPercent = (i - A) / (B - A) * 100;
                    progress.Progress = completionPercent;
                    label.Text = Convert.ToString(Math.Round(completionPercent * 100)) + "%";
                    if (Math.Round(completionPercent * 100) >= 100) break;
                    cancelTokenSource = new CancellationTokenSource();
                    token = cancelTokenSource.Token;
                }
                StartBtn.IsEnabled = true;
                header.Text = Convert.ToString(res);
                cancelTokenSource = new CancellationTokenSource();
                token = cancelTokenSource.Token;
                
            }
            catch(OperationCanceledException)
            {
                cancelTokenSource = new CancellationTokenSource();
                token = cancelTokenSource.Token;
            }
        }
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {    
        
            ProgressBar? progress = this.FindByName("Prgs") as ProgressBar;
            Label? header = this.FindByName("Header") as Label;
            StartBtn.IsEnabled = true;
            if (progress.Progress < 1.0 && header.Text == "Running")
            {
                cancelTokenSource.Cancel();
                header.Text = "Operation canceled!";
            }
        
    }
}