using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cats
{
	public class CatsViewModel : INotifyPropertyChanged
	{
		private bool Busy;
		public ObservableCollection<Cat> Cats { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public CatsViewModel()
		{
			Cats = new ObservableCollection<Cats.Cat>();
			GetCatsCommand = new Command(
				async () => await GetCats(),
				() => !IsBusy
				);

		}

		public bool IsBusy
		{
			get
			{
				return Busy;
			}
			set
			{
				Busy = value;
				OnPropertyChanged();
				GetCatsCommand.ChangeCanExecute();
			}
		}




		private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]
								string propertyName = null) =>
								PropertyChanged?.Invoke(this,
									new PropertyChangedEventArgs(propertyName));

		async Task GetCats()
		{
			if (!IsBusy)
			{
				Exception Error = null;

				try
				{
					IsBusy = true;
					var Repository = new Repository();
					var Items = await Repository.GetCats();
					Cats.Clear();
					foreach (var Cat in Items)
					{
						Cats.Add(Cat);
					}
				}
				catch (Exception ex)
				{
					Error = ex;
				}
				finally
				{
					IsBusy = false;
				}
				if (Error != null)
				{
					await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
						"Erro na comunicaçao com API de gatos!", Error.Message, "OK");
				}
			}
			return;
		}

		public Command GetCatsCommand { get; set; }
	}
}
