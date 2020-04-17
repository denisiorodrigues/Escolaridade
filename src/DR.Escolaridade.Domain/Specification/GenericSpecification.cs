using DomainValidation.Interfaces.Specification;
using DR.Escolaridade.Domain.Models;
using System;
using System.Linq.Expressions;

namespace DR.Escolaridade.Domain.Specification
{
    public class GenericSpecification <T>: ISpecification<T>  where T : Entity
    {
        public Expression<Func<T, bool>> Expression { get; }

        public GenericSpecification(Expression<Func<T, bool>> expression)
        {
            this.Expression = expression;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return Expression.Compile().Invoke(entity);
        }
    }
}