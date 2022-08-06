using Microsoft.EntityFrameworkCore;
using StoreAppLib.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
	/// Lógica de interacción para Signing.xaml
	/// </summary>
	public partial class Signing : Window
	{
		private static readonly Regex _numbersOnly = new Regex("[^0-9.-]+");
		private static readonly Regex _lettersOnly = new Regex("[^a-zA-Z]+");
		private ClientContext? _context;


		public Signing()
		{
			InitializeComponent();
		}

		public async Task LoadContext()
		{
			try
			{
				_context = new();
				await _context.Client.LoadAsync();
			}
			catch (Exception)
			{
				//
			}
		}

		private async Task Login(string id)
		{
			try
			{
				var client = await _context.Client.SingleAsync(c => c.IdentificationNumber.Trim() == id.Trim());
				new MainWindow(client).Show();
				this.Close();
			}
			catch(Exception)
			{
				MessageBox.Show("Client not found on the database","Login error",MessageBoxButton.OK,MessageBoxImage.Error);
			}
		}
		private void OnlyNumbersAllowed(object sender, TextCompositionEventArgs e)
		{
			e.Handled = _numbersOnly.IsMatch(e.Text);
		}
		private void OnlyLettersAllowed(object sender, TextCompositionEventArgs e)
		{
			e.Handled = _lettersOnly.IsMatch(e.Text);
		}

		private async void SignUpButton_Click(object sender, RoutedEventArgs e)
		{
			bool newClient;

			try
			{
				await _context.Client.SingleAsync(c => c.IdentificationNumber.Trim() == SignUpIDTextBox.Text);
				newClient = true;
			}
			catch (Exception)
			{
				newClient = false;
			}

			if (!newClient)
			{
				await _context.Client.AddAsync(new StoreAppLib.Models.Client
				{
					IdClient = (await _context.Client.CountAsync())+1,
					Name = SignUpNameTextBox.Text,
					Lastname = SignUpLastnameTextBox.Text,
					IdentificationNumber = SignUpIDTextBox.Text,
					Address = SignUpAddressTextBox.Text,
					PhoneNumber = SignUpPhoneTextBox.Text,
				}); 
			}

			await _context.SaveChangesAsync();

			await Login(SignUpIDTextBox.Text);
		}

		private async void LogInButton_Click(object sender, RoutedEventArgs e)
		{
			await Login(LogInNameTextBox.Text);
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			new Connect(this).Show();
		}

		private async void Window_Closed(object sender, EventArgs e)
		{
			await _context.DisposeAsync();
		}
	}
}
