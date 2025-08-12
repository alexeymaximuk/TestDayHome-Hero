using System;
using MessagePipe;
using Scrips.Domain.MessagesDTO;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace Scrips.Controllers
{
    public class UserInputController : IInitializable, IDisposable
    {
        [Inject] private readonly IPublisher<OnUserTapDTO> _onUserTapPublisher;
        [Inject] private readonly PlayerInput _playerInput;

        public void Initialize()
        {
            _playerInput.uiInputModule.leftClick.action.performed += OnLeftClickPerformed;
        }

        public void Dispose()
        {
            _playerInput.uiInputModule.leftClick.action.performed -= OnLeftClickPerformed;
        }
        
        private void OnLeftClickPerformed(InputAction.CallbackContext context)
        {
            var mousePosition = Mouse.current.position.ReadValue();
            
            _onUserTapPublisher.Publish(new OnUserTapDTO(mousePosition));
        }
    }
}