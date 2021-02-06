using System;
using System.Collections.Generic;
using System.Text;

namespace TabulaturiRO
{
   public class MasterPageItem
   {
		public string Title { get; set; }

		public string IconSource { get; set; }

		public int Size { get; set; }

		public int SizeImg { get; set; }


		public string VertOptions { get; set; }

		public string HorOptions { get; set; }
			
		public Type TargetType { get; set; }
	}
}
