namespace Scrips.Domain.MessagesDTO
{
    public struct OnHeroStatSelectedDTO
    {
        public string StatId { get; }
        public OnHeroStatSelectedDTO(string statId)
        {
            StatId = statId;
        }
    }
}