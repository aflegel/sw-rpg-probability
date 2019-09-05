﻿using Xunit;
using Visualizer.Controllers;
using System.Linq;
using FluentAssertions;

namespace Visualizer.Tests
{
	[Collection(APICommon.DatabaseCollection)]
	public class RollControllerTests
	{
		private readonly RollController controller;

		public RollControllerTests(DatabaseFixture fixture)
		{
			controller = new RollController(fixture.Context);
		}

		[Fact]
		public void ResultsPositive()
		{
			var result = controller.Get(APICommon.PositiveModel.Dice.ToList());
			result.PositiveRolls.Results.Should().HaveCount(15, "Positive statistics count incorrect");
			result.PositiveRolls.Dice.Should().HaveCount(1);
			result.PositiveRolls.Dice.First().DieType.Should().Be("Ability");

			result.NegativeRolls.Results.Should().HaveCount(15, "Negative statistics count incorrect");
			result.NegativeRolls.Dice.Should().HaveCount(1);
			result.NegativeRolls.Dice.First().DieType.Should().Be("Difficulty");
		}

		[Fact]
		public void ResultsNegative()
		{
			var result = controller.Get(APICommon.NegativeModel.Dice.ToList());
			result.PositiveRolls.Results.Should().HaveCount(0, "Positive statistics count incorrect");
			result.PositiveRolls.Dice.Should().HaveCount(0);

			result.NegativeRolls.Results.Should().HaveCount(0, "Negative statistics count incorrect");
			result.NegativeRolls.Dice.Should().HaveCount(0);
		}
	}
}
