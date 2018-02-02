using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MyGymApp
{
	public class NewGymSessionViewModel:INotifyPropertyChanged
	{
		GymDataBasse db;
		public ICommand SaveEntry;
		public DateTimeOffset Checkin { get; set; }
		public DateTimeOffset CheckOut { get; set; }
		ObservableCollection<Reason> reasons;
		public ObservableCollection<Reason> Reasons
		{
			set
			{
				GetReasons();
				OnPropertyChanged(nameof(Reasons));
			}
			get
			{
				return reasons;
			}
		}


		public NewGymSessionViewModel()
		{
			db = new GymDataBasse();
		}

		private void GetReasons()
		{
			var r= db.GetReasons();
			foreach (var item in r)
			{
				reasons.Add(item);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// Ons the property changed.
		/// </summary>
		/// <param name="propertyName">Property name.</param>
		void OnPropertyChanged(string propertyName)
		{
			//PropertyChangedEventHandler eventHandler = this.PropertyChanged;
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));		
			}
        }
	}
}
