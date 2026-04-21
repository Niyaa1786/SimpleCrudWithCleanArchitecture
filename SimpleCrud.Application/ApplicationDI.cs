using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            // Register all validators in the assembly
            services.AddValidatorsFromAssemblyContaining<IValidatorMarker>();
            return services;
        }
    }
}
