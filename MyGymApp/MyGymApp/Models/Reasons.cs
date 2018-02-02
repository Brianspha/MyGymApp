using System;
using System.Collections.Generic;
using Realms;

namespace MyGymApp
{
	public class Reasons:RealmObject
	{
		public IList<Reason> reasons { get; }
	}
}
