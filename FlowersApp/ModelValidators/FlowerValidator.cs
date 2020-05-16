using FlowersApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowersApp.ModelValidators
{
	public class FlowerValidator : AbstractValidator<Flower>
	{
		public FlowerValidator()
		{
			RuleFor(x => x.MarketPrice)
				.InclusiveBetween(5, 1000);
			RuleFor(x => x.DateAdded)
				.LessThan(DateTime.Now);
			RuleFor(x => x.FlowerUpkeepDifficulty)
				.Equal(FlowerUpkeepDifficulty.Easy)
				.When(x => x.MarketPrice >= 5 && x.MarketPrice <= 10);
		}
	}
}
