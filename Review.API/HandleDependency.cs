using Data.DataAccess.Security;
using Data.Repository.Implementation;
using Data.Repository.Interface;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Review.API.DatabaseConfigurations;

namespace Review.API
{
    public static class HandleDependency
    {
        public static void InsertDependency(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ReviewProductDbContext).Assembly);
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
