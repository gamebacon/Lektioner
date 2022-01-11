using System;
public class Övning7 {
	public static void Main(string[] args) {
		new Övning7();
	}

	public Övning7() {
		float[] goldDays = { 12, 34, 4, 55, 2, 43, 12, 3443};
		BuyAndSell(goldDays);
	}

	
	public void BuyAndSell(float[] days) {

		int buy = 0;
		int sell = 0; 

		for(int j = 0; j < days.Length; j++) {
			float price = days[j];

			if(days[buy] > price)
				buy = j;

			if(days[sell] < price)
				sell = j;
		}

		Console.WriteLine(String.Format("Sell: {0}, Buy: {1}", sell, buy));
	}

}
