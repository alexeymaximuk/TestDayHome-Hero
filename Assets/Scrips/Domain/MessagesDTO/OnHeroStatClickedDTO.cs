namespace Scrips.Domain.MessagesDTO
{
    public struct OnHeroStatClickedDTO
    {
        public string Id { get; }
        public OnHeroStatClickedDTO(string id)
        {
            Id = id;
        }
    }
}