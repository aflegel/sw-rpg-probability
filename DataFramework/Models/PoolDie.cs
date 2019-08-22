﻿using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DataFramework.Models
{
	public class PoolDie
	{
		public PoolDie() { }

		public PoolDie(Die die, int quantity)
		{
			Die = die;
			Quantity = quantity;
		}

		public int DieId { get; set; }

		[JsonIgnore]
		public int PoolId { get; set; }

		public int Quantity { get; set; }

		[JsonIgnore]
		public Pool Pool { get; set; }

		[JsonIgnore]
		public Die Die { get; set; }
	}

	public static class PoolDieExtension
	{
		public static int SumQuantity(this ICollection<PoolDie> dice) => dice.Sum(die => die.Quantity);
	}
}
