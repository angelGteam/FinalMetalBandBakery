namespace MetalBandBakery.Services
{
	public class ChangeCalculator
	{
		public static decimal Calculate(decimal amountPaid, decimal amountToPay)
		{
			return amountPaid - amountToPay;
		}

		public static bool CanBeCalculate(decimal amountPaid, decimal amountToPay)
		{
			return amountPaid > amountToPay;
		}
	}
}