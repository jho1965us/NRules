using System;
using System.Collections.Generic;

namespace NRules.RuleModel
{
    /// <summary>
    /// Rule element that creates new facts (aggregates) based on matching facts it receives as input.
    /// </summary>
    public class AggregateElement : PatternSourceElement
    {
        private readonly IAggregatorFactory _factory;
        private readonly PatternElement _source;

        /// <summary>
        /// Factory to create aggregators of this type.
        /// </summary>
        public IAggregatorFactory AggregatorFactory
        {
            get { return _factory; }
        }

        /// <summary>
        /// Fact source of the aggregate.
        /// </summary>
        public PatternElement Source
        {
            get { return _source; }
        }

        internal AggregateElement(IEnumerable<Declaration> declarations, Type resultType, IAggregatorFactory factory, PatternElement source) 
            : base(declarations, resultType)
        {
            _factory = factory;
            _source = source;
        }

        internal override void Accept<TContext>(TContext context, RuleElementVisitor<TContext> visitor)
        {
            visitor.VisitAggregate(context, this);
        }
    }
}