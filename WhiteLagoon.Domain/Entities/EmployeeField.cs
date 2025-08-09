namespace WhiteLagoon.Domain.Entities
{
    public class EmployeeField
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public FieldType Type { get; set; }
        public bool IsRequired { get; set; }

        public string? DropdownOptions { get; set; }
    }

    public enum FieldType
    {
        String,
        Integer,
        Date,
        Dropdown
    }
}
