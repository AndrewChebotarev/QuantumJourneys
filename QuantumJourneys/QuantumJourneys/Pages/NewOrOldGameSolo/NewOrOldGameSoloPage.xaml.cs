namespace QuantumJourneys.Pages;

public partial class NewOrOldGameSolo : ContentPage
{
	public NewOrOldGameSolo()
	{
		InitializeComponent();
	}

    private async void SoloGameBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}