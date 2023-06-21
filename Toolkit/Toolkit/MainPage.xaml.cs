namespace Toolkit
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void QR_Generator_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.QRPage(), false);
        }
    }
}