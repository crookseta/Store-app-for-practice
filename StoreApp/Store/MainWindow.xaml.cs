using Microsoft.EntityFrameworkCore;
using StoreAppLib.DataAccess;
using StoreAppLib.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Store
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly BillDetailContext _context = new();
		private readonly Client? _client;
		private CollectionViewSource _productViewSource;
		private CollectionViewSource _billViewSource;
		private CollectionViewSource _detailViewSource;
		private List<BillDetail> _details = new();
		private int _billsCount;

		public MainWindow()
		{
			InitializeComponent();
			_productViewSource = (CollectionViewSource)TryFindResource("productViewSource");
			_billViewSource = (CollectionViewSource)TryFindResource("billViewSource");
			_detailViewSource = (CollectionViewSource)TryFindResource("detailViewSource");
		}

		public MainWindow(Client clientId) : this()
		{
			_client = clientId;
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// load the entities into EF Core
			await _context.Product.LoadAsync();
			await _context.Bill.LoadAsync();
			await _context.BillDetail.LoadAsync();

			_billsCount = await _context.Bill.CountAsync();

			// bind to the source
			_productViewSource.Source =
				_context.Product.Local.ToObservableCollection();
			_billViewSource.Source =
				_context.Bill.Local.ToObservableCollection();
			_detailViewSource.Source =
				_details;
		}

		private async void Button_Click(object sender, RoutedEventArgs e) //Save Button
		{
			if (_details.Any())
			{
				// Creating a new bill and linking it to each bill detail
				var newBill = new Bill
				{
					IdBill = _billsCount+1,
					BillNumber = new Random().NextInt64(9999999999).ToString().PadLeft(10, '0'),
					Date = DateTime.UtcNow,
					IdClient = _client!.IdClient,
					//Client = _client
				};

				foreach (var d in _details) 
				{
					d.Bill = newBill;
				}
				_context.Bill.Add(newBill);
				_context.BillDetail.AddRange(_details);
			}
			_details.Clear();

			// all changes are automatically tracked, including
			// deletes!
			await _context.SaveChangesAsync();
			_billsCount = await _context.Bill.CountAsync();

			// this forces the grid to refresh to latest values
			categoryDataGrid.Items.Refresh();
			productsDataGrid.Items.Refresh();
			detailsDataGrid.Items.Refresh();
		}

		private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// clean up database connections
			await _context.DisposeAsync();
		}

		private async void Window_Unloaded(object sender, RoutedEventArgs e)
		{
			await _context.DisposeAsync();
		}

		private async void categoryDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var prod = await _context.Product.SingleAsync(p => p.IdProduct == _context.Product.ToArray()[categoryDataGrid.SelectedIndex].IdProduct);
			var detail = _details.Find(d => d.IdProduct == prod.IdProduct);

			if (detail is not null)
			{
				detail.Quantity++;
			}
			else
			{
				_details.Add(
					new BillDetail
					{
						IdProduct = prod.IdProduct,
						Product = prod,
						IdBill = _billsCount,
						Quantity = 1
					}
				);
			}
			detailsDataGrid.Items.Refresh();
		}
	}
}
