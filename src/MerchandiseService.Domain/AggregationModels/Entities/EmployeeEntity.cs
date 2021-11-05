using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.Entities
{
    public sealed class EmployeeEntity : Entity
    {
        public string Name { get; }

        public EmployeeEntity(int id)
        {
            this.Id = id;
        }

        public EmployeeEntity(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
