using LarDePaz_API.Models.Constants;
namespace LarDePaz_API.Models.DTO
{
    public class PaginateRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
        public string ColumnSort { get; set; } = "createdAt";
        public string SortDirection { get; set; } = SortDirectionCode.DESC;
    }
}
