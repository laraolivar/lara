using System;
using System.Globalization;
using System.ComponentModel;
using Xamarin.Forms;

namespace App5
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

		private void Button_Clicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new Page1());
		}

		private void Button_Clicked_1(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new Page2());
		}
	}
	class DoubleToIntConverter : IValueConverter
	{
		public object Convert(object value, Type targetType,
							  object parameter, CultureInfo culture)
		{
			double multiplier;

			if (!Double.TryParse(parameter as string, out multiplier))
				multiplier = 1;

			return (int)Math.Round(multiplier * (double)value);
		}

		public object ConvertBack(object value, Type targetType,
								  object parameter, CultureInfo culture)
		{
			double divider;

			if (!Double.TryParse(parameter as string, out divider))
				divider = 1;

			return ((double)(int)value) / divider;
		}
	}
	public class HslViewModel : INotifyPropertyChanged
	{
		double hue, saturation, luminosity;
		Color color;

		public event PropertyChangedEventHandler PropertyChanged;

		public double Hue
		{
			set
			{
				if (hue != value)
				{
					hue = value;
					OnPropertyChanged("Hue");
					SetNewColor();
				}
			}
			get
			{
				return hue;
			}
		}

		public double Saturation
		{
			set
			{
				if (saturation != value)
				{
					saturation = value;
					OnPropertyChanged("Saturation");
					SetNewColor();
				}
			}
			get
			{
				return saturation;
			}
		}

		public double Luminosity
		{
			set
			{
				if (luminosity != value)
				{
					luminosity = value;
					OnPropertyChanged("Luminosity");
					SetNewColor();
				}
			}
			get
			{
				return luminosity;
			}
		}

		public Color Color
		{
			set
			{
				if (color != value)
				{
					color = value;
					OnPropertyChanged("Color");

					Hue = value.Hue;
					Saturation = value.Saturation;
					Luminosity = value.Luminosity;
				}
			}
			get
			{
				return color;
			}
		}

		void SetNewColor()
		{
			Color = Color.FromHsla(Hue, Saturation, Luminosity);
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
