using WazeCredit.Models;

namespace WazeCredit.Service
{
    public class MarketForecasterV2: IMarketForecaster
    {
        public MarketResult GetMarketPrediction()
        {
            // call api to do some complex calculations and current stock market forcast
            return new MarketResult
            {
                MarketCondition = MarketCondition.Volatile
            };
        }
    }
}
