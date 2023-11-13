using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

public class Startup
{
  public Startup 
  {
    public void ConfigureServices(IServiceCollection services)
    {
        // services.AddCors();
        services.AddControllers();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = "https://www.yogihosting.com",
                ValidIssuer = "https://www.yogihosting.com",
                ClockSkew = TimeSpan.Zero,// It forces tokens to expire exactly at token expiration time instead of 5 minutes later
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond007"))
            };
        });
    }
  }
}