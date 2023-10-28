namespace QuantumJourneys.Pages;

public partial class NewOrOldGameSolo : ContentPage
{
	public NewOrOldGameSolo()
	{
		InitializeComponent();
	}

    private void SoloGameBtn_Clicked(object sender, EventArgs e)
    {
        // �������� ����� ��������
        var nextPage = new MainPage();

        // ��������� �������� Page �������
        var currentPage = Application.Current.MainPage;

        // �������� ������� ��������
        currentPage.Navigation.PopAsync();

        // ��������� ����� �������� � �������� MainPage
        Application.Current.MainPage = nextPage;
    }
}