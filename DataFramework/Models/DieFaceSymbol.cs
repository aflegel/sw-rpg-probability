﻿using Newtonsoft.Json;
using static DataFramework.Models.Die;

namespace DataFramework.Models
{
	public class DieFaceSymbol
	{
		public DieFaceSymbol(Symbol symbol, int quantity)
		{
			Symbol = symbol;
			Quantity = quantity;
		}

		public int DieFaceId { get; set; }

		public Symbol Symbol { get; set; }

		public int Quantity { get; set; }

		[JsonIgnore]
		public DieFace DieFace { get; set; }
	}
}
