namespace CompanyEmployees.Domain.Shared.RequestFeatures
{
    public class PagedList<T> : List<T>
    {
        public PaginationMetaData MetaData { get; set; }

        public PagedList(List<T> itema, int count, int pageIndex, int pageSize)
        {
            MetaData = new PaginationMetaData
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                TotalCount = count
            };

            AddRange(itema);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int count, int pageIndex, int pageSize)
        {
            var list = source.ToList();

            return new PagedList<T>(list, count, pageIndex, pageSize);
        }
    }
}
