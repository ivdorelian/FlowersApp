using FlowersApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FlowersApp.ModelValidators
{
	public class FlowerValidator : AbstractValidator<Flower>
	{
		// read more: https://www.carlrippon.com/fluentvalidation-in-an-asp-net-core-web-api/
		public FlowerValidator(FlowersDbContext context)
		{
			RuleFor(x => x.MarketPrice)
				.InclusiveBetween(5, context.Flowers.Select(f => f.MarketPrice).Max());
			RuleFor(x => x.DateAdded)
				.LessThan(DateTime.Now);
			RuleFor(x => x.FlowerUpkeepDifficulty)
				.Equal(FlowerUpkeepDifficulty.Easy)
				.When(x => x.MarketPrice >= 5 && x.MarketPrice <= 10);
		}
	}
}
