﻿namespace Merchello.Core.DependencyInjection
{
    using System;
    using System.Collections.Generic;

    using LightInject;

    /// <summary>
    /// Extension methods for <see cref="IServiceRegistry"/>
    /// </summary>
    internal static class LightInjectExtensions
    {
        /// <summary>
        /// Registers the TService with the factory that describes the dependencies of the service, as a singleton.
        /// </summary>
        /// <typeparam name="TService">
        /// The type of the service instance.
        /// </typeparam>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="serviceName">
        /// The service Name.
        /// </param>
        public static void RegisterSingleton<TService>(this IServiceRegistry container, Func<IServiceFactory, TService> factory, string serviceName)
        {
            container.Register(factory, serviceName, new PerContainerLifetime());
        }

        /// <summary>
        /// Registers the TService with the TImplementation as a singleton.
        /// </summary>
        /// <typeparam name="TService">
        /// The type of the service
        /// </typeparam>
        /// <typeparam name="TImplementation">
        /// The type of the instance
        /// </typeparam>
        /// <param name="container">
        /// The container.
        /// </param>
        public static void RegisterSingleton<TService, TImplementation>(this IServiceRegistry container) 
            where TImplementation : TService
        {
            container.Register<TService, TImplementation>(new PerContainerLifetime());
        }

        /// <summary>
        /// Registers a concrete type as a singleton service.
        /// </summary>
        /// <typeparam name="TImplementation">
        /// The type of the instance.
        /// </typeparam>
        /// <param name="container">
        /// The container.
        /// </param>
        public static void RegisterSingleton<TImplementation>(this IServiceRegistry container)
        {
            container.Register<TImplementation>(new PerContainerLifetime());
        }

        /// <summary>
        /// Registers the TService with the factory that describes the dependencies of the service, as a singleton.
        /// </summary>
        /// <typeparam name="TService">
        /// The type of the service.
        /// </typeparam>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="factory">
        /// The factory.
        /// </param>
        public static void RegisterSingleton<TService>(this IServiceRegistry container, Func<IServiceFactory, TService> factory)
        {
            container.Register(factory, new PerContainerLifetime());
        }

        /// <summary>
        /// In order for LightInject to deal with enumerable(s) of the same type, each one needs to be registered as their explicit types
        /// </summary>
        /// <typeparam name="TLifetime">
        /// The lifetime scope.
        /// </typeparam>
        /// <param name="container">
        /// The container
        /// </param>
        /// <param name="implementationTypes">
        /// The types of the implementations.
        /// </param>
        /// <remarks>
        /// This works as of 3.0.2.2
        /// but means that the explicit type is registered, not the implementing type
        /// </remarks>
        /// <seealso cref="https://github.com/seesharper/LightInject/issues/68#issuecomment-70611055"/>
        public static void RegisterCollection<TLifetime>(this IServiceContainer container, IEnumerable<Type> implementationTypes)
            where TLifetime : ILifetime, new()
        {
            foreach (var type in implementationTypes)
            {
                container.Register(type, new TLifetime());                
            }
        }

        /// <summary>
        /// In order for LightInject to deal with enumerable(s) of the same type, each one needs to be registered as their explicit types
        /// </summary>
        /// <param name="container">The container</param>
        /// <param name="implementationTypes">
        /// The types of the instances
        /// </param>
        /// <remarks>
        /// This works as of 3.0.2.2
        /// but means that the explicit type is registered, not the implementing type
        /// </remarks>
        /// <seealso cref="https://github.com/seesharper/LightInject/issues/68#issuecomment-70611055"/>
        public static void RegisterCollection(this IServiceContainer container, IEnumerable<Type> implementationTypes)
        {
            foreach (var type in implementationTypes)
            {                
                container.Register(type);                
            }
        }       
    }
}