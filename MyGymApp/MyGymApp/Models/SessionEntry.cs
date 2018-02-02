using System;
using Realms;
namespace MyGymApp
{
	public class SesionEntry:RealmObject
	{
		public DateTimeOffset CheckinTime { get; set; }
		public DateTimeOffset CheckOutTime { get; set; }
		public bool CantAttendSession { get; set; }
		public Reason reason { get; set; }
		public bool IsCurrent { get; set;}
	}
}
