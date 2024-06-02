using System.Security;

namespace StalNoteSite.Api
{
    public static class ApiBuilder
    {
        private static WebApplication webApp = null;
        private static Guid SecurityStamp;
        private static void InitUser()
        {
            var context = new ApplicationDbContext();

            webApp.MapGet("/api/{securityStamp}/users", (Guid securityStamp) => 
            {
                if (SecurityStamp != securityStamp)
                {
                    return Results.Unauthorized();
                }
                return Results.Json(context.Users.Take(20));
            });

            

            webApp.MapGet("api/{securityStamp}/users/{id}", (Guid securityStamp,string id) =>
            {
                if (SecurityStamp != securityStamp)
                {
                    return Results.Unauthorized();
                }
                long digitId = 0;
                User? user = null;
                if (long.TryParse(id, out digitId))
                {
                    user = context.Users.Where(x => x.Id == digitId).FirstOrDefault();
                }
                else
                {
                    return Results.NotFound(new { message = "Пользователь не найден или id был введен неверно" });
                }
                return Results.Json(user);
            });

        }


        public static void Initial(WebApplication? app)
        {
            SecurityStamp = Guid.NewGuid();

            webApp = app;
            InitUser();
            
        }
    }
}
