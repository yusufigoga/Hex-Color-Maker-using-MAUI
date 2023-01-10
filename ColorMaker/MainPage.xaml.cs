using Android.OS;
using System.Diagnostics;
using Debug = System.Diagnostics.Debug;
using CommunityToolkit.Maui.Core;
using Android.Widget;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
	string hexValue;

	public MainPage()
	{
		InitializeComponent();
	}

	private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		var red = sldred.Value;
		var green = sldgreen.Value;
		var blue = sldblue.Value;

		Color color = Color.FromRgb(red, green, blue);

		SetColor(color);
	}

	private void SetColor(Color color)
	{
		Debug.WriteLine(color.ToString());
		btbRan.BackgroundColor = color;
		Container.BackgroundColor = color;
		hexValue = color.ToHex();
		lblHex.Text = color.ToHex();
	}

        private void btnRan_Clicked(object sender, EventArgs e)
	{
		var ranadom = new Random();

		var color = Color.FromRgb(
            ranadom.Next(0,256),
            ranadom.Next(0, 256),
            ranadom.Next(0, 256));

		SetColor(color);

		sldred.Value = color.Red;
		sldgreen.Value = color.Green;
		sldblue.Value = color.Blue;
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(hexValue);
	}
}

