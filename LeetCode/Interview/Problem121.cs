namespace LeetCode.Interview;
/// <summary>
///     121. Best Time to Buy and Sell Stock
///     https://leetcode.com/problems/best-time-to-buy-and-sell-stock
/// </summary>
public class Problem121
{
    public int MaxProfit(int[] prices)
    {
        if ( prices.Length < 2 )
        {
            return 0;
        }

        int profit = 0;
        int bPrice = prices[0];

        for ( int i = 1; i < prices.Length; i++ )
        {
            int sPrice = prices[i];

            if ( bPrice >= sPrice )
            {
                bPrice = sPrice;
            }
            else
            {
                int currProfit = sPrice - bPrice;
                if ( currProfit > profit )
                {
                    profit = currProfit;
                }
            }
        }

        return profit;
    }

    [Theory]
    [InlineData(new[] {7, 1, 5, 3, 6, 4}, 5)]
    [InlineData(new[] {7, 6, 4, 3, 1}, 0)]
    [InlineData(new[] {1, 2}, 1)]
    public void CanMaxProfit(int[] prices, int expected) =>
        MaxProfit(prices).Should().Be(expected);
}
