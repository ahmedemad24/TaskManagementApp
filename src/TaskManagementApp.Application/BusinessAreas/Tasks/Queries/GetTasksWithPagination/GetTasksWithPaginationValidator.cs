using FluentValidation;
using Microsoft.Extensions.Options;
using TaskManagementApp.Application.Models;

namespace TaskManagementApp.Application.BusinessAreas.Tasks.Queries.GetTasksWithPagination
{
    public class GetTasksWithPaginationValidator : AbstractValidator<GetTasksWithPaginationQuery>
    {
        public GetTasksWithPaginationValidator(IOptions<SearchLimitsConfig> options)
        {
            var maxPageSize = options.Value.MaxPageSize;

            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .LessThanOrEqualTo(maxPageSize)
                .WithMessage($"Page size must be between 1 and {maxPageSize}.");
        }
    }
}
