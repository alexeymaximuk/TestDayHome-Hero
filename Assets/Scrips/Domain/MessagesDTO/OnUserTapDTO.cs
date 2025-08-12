using UnityEngine;

namespace Scrips.Domain.MessagesDTO
{
    public struct OnUserTapDTO
    {
        public Vector2 Position { get; }
        public OnUserTapDTO(Vector2 position)
        {
            Position = position;
        }
    }
}