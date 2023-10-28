namespace QuantumJourneys.Pages.SettingPage;

public partial class SettingPage : ContentPage
{
	public SettingPage()
	{
		InitializeComponent();
	}
    private void SoloGameBtn_Clicked(object sender, EventArgs e)
    {
        // Создание новой страницы
        var nextPage = new MainPage();

        // Получение текущего Page объекта
        var currentPage = Application.Current.MainPage;

        // Закрытие текущей страницы
        currentPage.Navigation.PopAsync();

        // Установка новой страницы в качестве MainPage
        Application.Current.MainPage = nextPage;
    }
}