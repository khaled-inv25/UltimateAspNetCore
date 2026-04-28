namespace CompanyEmployees.Application.Contract
{
    public class EntityDto<TId> where TId : IEquatable<TId>
    {
        public TId Id { get; set; }
    }
}
