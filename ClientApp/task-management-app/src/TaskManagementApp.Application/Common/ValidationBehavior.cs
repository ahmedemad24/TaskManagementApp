using FluentValidation;
using MediatR;

namespace TaskManagementApp.Application.Common
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count > 0)
            {
                var errorMessage = string.Join("; ", failures.Select(f => $"{f.PropertyName}: {f.ErrorMessage}"));

                // If TResponse is Result<T>, call Result.Failure<T>(error)
                if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var innerType = typeof(TResponse).GetGenericArguments()[0];
                    var method = typeof(Result)
                        .GetMethods()
                        .First(m => m.Name == "Failure" && m.IsGenericMethod && m.GetParameters().Length == 1);

                    var genericFailure = method.MakeGenericMethod(innerType);
                    return (TResponse)genericFailure.Invoke(null, [errorMessage])!;
                }

                // fallback throw
                throw new ValidationException(failures);
            }

            return await next(cancellationToken);
        }
    }
}
