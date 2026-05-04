using CompanyEmployees.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyEmployees.EntityFramework.Data
{
    public class EmployeeDataSeeder : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(Employees());
        }

        private Employee[] Employees()
        {
            Employee[] data = [
                new Employee { Id = new Guid("ffa02d9a-37d9-4565-9f2f-bfd079666116"), Name = "Khaled Ali", Age = 30, Position = "Software developer", CompanyId =  new Guid("a627d731-5382-4bf4-87c0-4f256fddd004")},
                new Employee { Id = new Guid("b222cc38-2ecb-4314-88e9-2c8a7ce4a554"), Name = "Mohammed Al-Batool", Age = 24, Position = "Mobile developer", CompanyId = new Guid("a627d731-5382-4bf4-87c0-4f256fddd004") },
                new Employee { Id = new Guid("fc61c65c-1861-4d0d-b091-8c85a2c21171"), Name = "Osamah Al-Obary", Age = 24, Position = "Software developer", CompanyId = new Guid("a627d731-5382-4bf4-87c0-4f256fddd004") },
                new Employee { Id = new Guid("babb5dff-d056-4620-a14c-4acc2f421af6"), Name = "Ahmed Al-Hemuary", Age = 26, Position = "Tester", CompanyId = new Guid("a627d731-5382-4bf4-87c0-4f256fddd004")},
                new Employee { Id = new Guid("a4ff3237-13c3-4ee1-9f8b-57d2e38b997a"), Name = "Osamah Salam", Age = 32 , Position = "Customer service", CompanyId = new Guid("73625b4e-4149-4912-b6d9-08a595d78124")},
                new Employee { Id = new Guid("7cce86d2-ee60-4de9-a098-ab8e45cce73a"), Name = "Sam Raiden", Age = 26, Position = "Accounting", CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                new Employee { Id = new Guid("ae6dff3c-abf4-4d79-a74e-3e14648db2f5"), Name = "Jana McLeaf", Age = 30, Position = "Marketing ", CompanyId =  new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                new Employee { Id = new Guid("50c1aed5-a50a-4f64-9533-910e68c30206"), Name = "Kane Miller", Age = 35, Position = "Adminstrater", CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3") }
                ];

            return data;
        }
    }
}

