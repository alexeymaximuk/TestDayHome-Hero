using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Scrips.Controllers;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Scrips.Infrastructure.Installers
{
    public class UserInputInstaller : LifetimeScope
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private UIDocument _uiDocument;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_playerInput);
            builder.RegisterInstance(_uiDocument);
            
            builder.Register<UserInputController>(Lifetime.Singleton).As<IInitializable>().As<IDisposable>();
        }
    }
}