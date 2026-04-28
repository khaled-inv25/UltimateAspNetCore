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
                new Employee { Id = new Guid("bc1f78cf-c7e3-4e78-b5d9-f4a1a3a1ddce"), Name = "Khaled Ali", Age = 30, CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), Position = "Sofrware Developer" },
                new Employee { Id = new Guid("617f7f3f-1188-47c8-9ecc-df285c605fa0"), Name = "Mohammed Al-Batool", Age = 24, CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), Position = "Mobile Developer" },
                new Employee { Id = new Guid("6adcb64f-178f-4a37-bc3a-0261972d9375"), Name = "Osamah Al-Obary", Age = 24, CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), Position = "Software Developer" },
                new Employee { Id = new Guid("babb5dff-d056-4620-a14c-4acc2f421af6"), Name = "Ahmed Al-Hemuary", Age = 26, CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), Position = "Tester" },
                new Employee { Id = new Guid("a4ff3237-13c3-4ee1-9f8b-57d2e38b997a"), Name = "Osamah Salam", Age = 32, CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), Position = "Customer Service" },
                new Employee { Id = new Guid("7cce86d2-ee60-4de9-a098-ab8e45cce73a"), Name = "Sam Raiden", Age = 26, Position = "Software developer", CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                new Employee { Id = new Guid("ae6dff3c-abf4-4d79-a74e-3e14648db2f5"), Name = "Jana McLeaf", Age = 30, Position = "Software developer", CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") },
                new Employee { Id = new Guid("50c1aed5-a50a-4f64-9533-910e68c30206"), Name = "Kane Miller", Age = 35, Position = "Administrator", CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3") }
                ];

            return data;
        }
    }
}

