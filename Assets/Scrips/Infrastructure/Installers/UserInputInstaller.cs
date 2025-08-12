using UnityEngine;
using VContainer;
using VContainer.Unity;
using MessagePipe;
using Scrips.Controllers;
using Scrips.Domain.MessagesDTO;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Scrips.Infrastructure.Installers
{
    public class UserInputInstaller : LifetimeScope
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private UIDocument _uiDocument;

        protected override void Configure(IContainerBuilder builder)
        {
            var pipeOptions = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<OnUserTapDTO>(pipeOptions);
            builder.RegisterMessageBroker<OnHeroStatClickedDTO>(pipeOptions);
            
            builder.RegisterInstance(_playerInput);
            builder.RegisterInstance(_eventSystem);
            builder.RegisterInstance(_uiDocument);
            
            builder.RegisterEntryPoint<UserInputController>();
        }
    }
}