using System;

using Xamarin.Forms;

namespace MMVM_RacasGatos
{
	public class CatsPage : ContentPage
	{
		public CatsPage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

