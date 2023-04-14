namespace ProjectsManagement.Dtos.Country
{
    public class ResponseCountryDto
    {
        private object value;

        public int Id { get; set; }
        public string Name { get; set; }
        public ResponseCountryDto()
        {
        }

        public ResponseCountryDto(int Id, string Name)
        {
            this.Name = Name;
            this.Id = Id;

        }
    }
}