namespace Toolkit.Views;

public partial class QRPage : ContentPage
{
	public QRPage()
	{
		InitializeComponent();
		
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        QR.Barcode = QRText.Text + " ";
    }
}