using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using WazeCredit.Models;
using WazeCredit.Models.ViewModels;
using WazeCredit.Service;
using WazeCredit.Utility.AppSettingClasses;

namespace WazeCredit.Controllers
{
    public class HomeController : Controller
    {

        public HomeVM homeVM { get; set; }
        private readonly IMarketForecaster _marketForecaster;
        private readonly StripeSetting _stripeSetting;
        private readonly SendGridSetting _sendGridSetting;
        private readonly TwilioSetting _twilioSetting;
        private readonly WazeForecastSetting _wazeForecastSetting;
        public HomeController(IMarketForecaster marketForecaster,IOptions<StripeSetting> stripeoption, 
            IOptions<SendGridSetting> sendGrideOptions, IOptions<TwilioSetting> twilioOptions, IOptions<WazeForecastSetting> wazeForcastOption)
        {
            homeVM = new HomeVM();
            _marketForecaster = marketForecaster;
            _stripeSetting = stripeoption.Value;
            _sendGridSetting = sendGrideOptions.Value;
            _twilioSetting = twilioOptions.Value;
            _wazeForecastSetting = wazeForcastOption.Value;
        }

        public IActionResult Index()
        {
            MarketResult currentMarket=_marketForecaster.GetMarketPrediction();
            switch (currentMarket.MarketCondition)
            {
                case MarketCondition.StableDown:
                    homeVM.MarketForecast = "Market shows signs to go down in a stable state! It is a not a good sign to apply for credit applications! But extra credit is always piece of mind if you have handy when you need it.";
                    break;
                case MarketCondition.StableUp:
                    homeVM.MarketForecast = "Market shows signs to go up in a stable state! It is a great sign to apply for credit applications!";
                    break;
                case MarketCondition.Volatile:
                    homeVM.MarketForecast = "Market shows signs of volatility. In uncertain times, it is good to have credit handy if you need extra funds!";
                    break;
                default:
                    homeVM.MarketForecast = "Apply for a credit card using our application!";
                    break;
            }
            return View(homeVM);
        }

        public IActionResult AllConfigSetting()
        {
            List<string> message=new List<string>();
            message.Add($"Stripe Key: {_stripeSetting.SecretKey}");
            message.Add($"Stripe PublishableKey: {_stripeSetting.PublishableKey}");
            message.Add($"SendGrid Key: {_sendGridSetting.SendGridKey}");
            message.Add($"Twilio PhoneNumber: {_twilioSetting.PhoneNumber}");
            message.Add($"Twilio AuthToken: {_twilioSetting.AuthToken}");
            message.Add($"Twilio AccountSid: {_twilioSetting.AccountSid}");
            message.Add($"Waze Forecast Tracker Enabled: {_wazeForecastSetting.ForecastTrackerEnabled}");
            return View(message);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
