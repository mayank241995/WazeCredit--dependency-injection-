using WazeCredit.Models;

namespace WazeCredit.Service
{
    public class MarketForecaster : IMarketForecaster
    {
        public MarketResult GetMarketPrediction()
        {
            // call api to do some complex calculations and current stock market forcast
            return new MarketResult
            {
                MarketCondition = MarketCondition.StableUp
            };
        }
    }
}
