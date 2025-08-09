namespace WhiteLagoon.Domain.Entities
{
    public class EmployeeFieldValue
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int FieldId { get; set; }
        public EmployeeField Field { get; set; }

        public string Value { get; set; }
    }
}
