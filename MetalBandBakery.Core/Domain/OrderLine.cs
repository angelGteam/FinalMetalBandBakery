﻿namespace MetalBandBakery.Core.Domain
{
	public class OrderLine
	{
		public OrderLine(string itemId, int amount)
		{
			ItemId = itemId;
			Amount = amount;
		}

		public int Amount { get; private set; }
		public decimal BasePrice { get; set; }
		public string ItemId { get; private set; }
		public decimal TotalPrice { get { return Amount * BasePrice; } }

		public void IncresaseAmount()
		{
			Amount++;
		}
	}
}