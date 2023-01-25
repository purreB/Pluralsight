using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseLibrary.API
{
  public static class StartupExtensions
  {
    public static IServiceCollection AddCache(this IServiceCollection services)
    {
      services.AddHttpCacheHeaders((expirationModelOptions) =>
        {
          expirationModelOptions.MaxAge = 60;
          expirationModelOptions.CacheLocation = Marvin.Cache.Headers.CacheLocation.Private;
        }, (validationModelOptions) =>
        {
          validationModelOptions.MustRevalidate = true;
        });
      services.AddResponseCaching();

      return services;
    }

    public static void SetupCache(this MvcOptions options)
    {
      options.ReturnHttpNotAcceptable = true;
      options.CacheProfiles.Add("240SecondsCacheProfile", new CacheProfile()
      {
        Duration = 240
      });
    }
  }
}