using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SimpleCrud.Application.UseCases.Categories;
using SimpleCrud.Application.UseCases.Products;
using SimpleCrud.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<CreateCategory>();
            services.AddScoped<GetAllCategories>();
            services.AddScoped<GetCategoryById>();
            services.AddScoped<UpdateCategory>();
            services.AddScoped<DeleteCategory>();

            services.AddScoped<CreateProduct>();
            services.AddScoped<GetAllProducts>();
            services.AddScoped<GetProductById>();
            services.AddScoped<GetAllProductsByCategory>();
            services.AddScoped<UpdateProduct>();
            services.AddScoped<DeleteProduct>();
            // Register all validators in the assembly
            services.AddValidatorsFromAssemblyContaining<IValidatorMarker>();
            return services;
        }
    }
}
