namespace Scrips.Domain.Hero.MessagesDTO
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