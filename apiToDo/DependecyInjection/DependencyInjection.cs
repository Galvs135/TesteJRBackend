using apiToDo.Models;
using Microsoft.Extensions.DependencyInjection;


namespace apiToDo.DependecyInjection
{
    public static class DependencyInjection
    {
        public static void AddDependecies(this IServiceCollection services)
        {
            RegisterModels(services);
        }

        private static void RegisterModels(IServiceCollection services) 
        {
            services.AddScoped<Tarefas>();
        }
    }
}
