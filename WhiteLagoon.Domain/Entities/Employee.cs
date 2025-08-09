namespace WhiteLagoon.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeFieldValue>? FieldValues { get; set; }
    }
}
