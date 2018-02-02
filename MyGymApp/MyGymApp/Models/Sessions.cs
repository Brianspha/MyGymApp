using System;
using System.Collections.Generic;
using Realms;
namespace MyGymApp
{
	public class Sesions:RealmObject
	{
		public IList<SesionEntry> SessionsDone { get;}
	}
}
