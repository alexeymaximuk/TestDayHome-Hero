namespace Scrips.Domain.MessagesDTO
{
    public struct LevelUpButtonClickedDTO
    {
        public readonly int CurrentLevel;

        public LevelUpButtonClickedDTO(int currentLevel)
        {
            CurrentLevel = currentLevel;
        }
        
    }
}