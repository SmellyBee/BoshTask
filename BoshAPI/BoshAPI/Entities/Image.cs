namespace BoshAPI.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public required Product Product { get; set; }
    }
}
