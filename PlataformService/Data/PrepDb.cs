namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var servicesScope = app.ApplicationServices.CreateScope())
            {
                SeedData(servicesScope.ServiceProvider.GetService<AppDbContext>());
            }
            
        }

        private static void SeedData(AppDbContext? context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("---> Seeding Data...");

                context.Platforms.AddRange(
                    new Models.Platform() {Name="Dot Net", Publisher="Microsoft", Cost="Free"},
                    new Models.Platform() {Name="Sql Server Express", Publisher="Microsoft", Cost="Free"},
                    new Models.Platform() {Name="Kubernets", Publisher="Cloud Native Computing Foundation", Cost="Free"}
                );

                context.SaveChanges();
            }
            else{
                Console.WriteLine("---> The DataBase already have data.");
            }
        }
    }
}