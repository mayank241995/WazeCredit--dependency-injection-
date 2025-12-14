using Microsoft.CodeAnalysis.CSharp.Syntax;
using WazeCredit.Utility.AppSettingClasses;

namespace WazeCredit.Utility.DI_config
{
    public static class DI_AppSettingConfig
    {
        public static IServiceCollection AddAppSettingConfig(this IServiceCollection Services,IConfiguration Configuration)
        {
            Services.Configure<WazeForecastSetting>(Configuration.GetSection("WazeForecast"));
            Services.Configure<TwilioSetting>(Configuration.GetSection("Twilio"));
            Services.Configure<StripeSetting>(Configuration.GetSection("Stripe"));
            Services.Configure<SendGridSetting>(Configuration.GetSection("SendGrid"));
            return Services;
        }
    }
}
