﻿using System.Data.Entity;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Azure.Mobile.Server.Tables.Config;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Zen.Tracker.Server.Site;
using Zen.Tracker.Server.Storage;

[assembly: OwinStartup(typeof(Startup))]

namespace Zen.Tracker.Server.Site
{
    /// <summary>
    /// Defines the application startup object
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configurations the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            // Create HTTP configuration object
            var httpConfig =
                new HttpConfiguration
                {
                    IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always
                };
            httpConfig.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            httpConfig.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            httpConfig.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            JsonConvert.DefaultSettings = 
                () => 
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore,
                };

            // Enable swagger support
            SwaggerConfig.Register(httpConfig);

            // Create autofac container (it may need to update the HTTP configuration)
            var builder = new ContainerBuilder();
            builder.RegisterModule(new IocModule(httpConfig));
            var container = builder.Build();

            // Get telemetry client and log
            var telemetryClient = container.Resolve<TelemetryClient>();
            telemetryClient.TrackEvent("Service startup");

            // Setup WEBAPI dependency resolver
            httpConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Setup mobile application app settings
            var provider = httpConfig.GetMobileAppSettingsProvider();
            var options = provider.GetMobileAppSettings();

            // Setup mobile app configuration settings
            var mobileAppConfig = new MobileAppConfiguration()
                //.MapApiControllers()
                .AddMobileAppHomeController()
                .AddPushNotifications()
                .AddTables(
                    new MobileAppTableConfiguration()
                        .MapTableControllers()
                        .AddEntityFramework());
            mobileAppConfig.ApplyTo(httpConfig);

            // Enable attribute routing for everything else we expose
            httpConfig.MapHttpAttributeRoutes();

            // Hook up autofac webapi controller dependency injection
            app.UseAutofacWebApi(httpConfig);
            app.UseWebApi(httpConfig);

            // Initialise database (including execution of any pending schema migrations)
            Database.SetInitializer(new MobileServiceInitializer());
        }
    }
}
