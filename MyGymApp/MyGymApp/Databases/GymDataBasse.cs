using System;
using System.Collections.Generic;
using Realms;
namespace MyGymApp
{
	public class GymDataBasse
	{
		Realm db;
		public GymDataBasse()
		{
			db = Realm.GetInstance();
		}

		public List<Reason> GetReasons()
		{
			var collection = db.All<Reason>().AsRealmCollection();
		    var list = new List<Reason>();
			foreach (Reason r in collection) list.Add(r);
			return list;
		}
		public void Addreason(Reason reason)
		{
			db.Write(() => {
				db.Add(reason);
			});
		}
		public void SaveEntry(SesionEntry ent)
		{
			db.Write(() => {
				var sessions = db.All<Sesions>().AsRealmCollection();
				if (sessions.Count > 0)
				{
					ent.IsCurrent = false;
					sessions[0].SessionsDone.Add(ent);
				}
				else
				{
					var sesh = new Sesions();					
					ent.IsCurrent = false;
					sesh.SessionsDone.Add(ent);
					db.Add(sesh);						
				}

			});
		}
		public Sesions GetSessionsDone()
		{
			var sessions = db.All<Sesions>().AsRealmCollection();
			if (sessions.Count > 0)
			{
				return sessions[0];
			}

			else return new Sesions();
		}
		public SesionEntry GetCurrentSesionEntry()
		{
			var collection =db.All<SesionEntry>().AsRealmCollection();
			var currentEntry = new SesionEntry();
			foreach (SesionEntry ent in collection) if (ent.IsCurrent) { currentEntry = ent; break; }
			return currentEntry;	
		}
	}
}
