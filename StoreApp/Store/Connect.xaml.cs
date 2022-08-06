using StoreAppLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Store
{
	/// <summary>
	/// Lógica de interacción para Connect.xaml
	/// </summary>
	public partial class Connect : Window
	{
		private readonly Signing? _signWin;

		public Connect()
		{
			InitializeComponent();
		}
		public Connect(Signing signWin) : this()
		{
			_signWin = signWin;
			signWin.IsEnabled = false;
			this.Focus();
		}

		private async void ConnectionButton_Click(object sender, RoutedEventArgs e)
		{
			Helper.ConnectionString = ConnectionStringBox.Text;

			if(await Helper.CheckConnection())
			{
				_signWin!.IsEnabled = true;
				await _signWin.LoadContext();
				_signWin.Focus();

				Close();
			}
			else
			{
				MessageBox.Show("Database not found", "Connection error", MessageBoxButton.OK, MessageBoxImage.Error);
				ConnectionStringBox.Text = String.Empty;
			}
		}
	}
}
