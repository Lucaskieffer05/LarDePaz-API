namespace LarDePaz_API.Services
{
    public class ServiceContainer
    {
        public static void AddServices(IServiceCollection services)
        {
            // User and Auth
            services.AddScoped<TokenService>();
            services.AddScoped<AuthService>();
            //services.AddScoped<UserService>();

            // Basic CRUDs
            //services.AddScoped<ProfessionService>();
            //services.AddScoped<SocialSecurityService>();
        }
    }
}
