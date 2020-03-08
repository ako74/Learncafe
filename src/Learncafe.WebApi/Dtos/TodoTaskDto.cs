namespace Learncafe.WebApi.Dtos
{
    public class TodoTaskDto
    {
        public string Name { get; set; }

        public TodoTaskDto(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException("message", nameof(name));
            }

            Name = name;
        }
    }
}