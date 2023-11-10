using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using InsuranceSystem.Models;
using Microsoft.Extensions.Logging;

namespace InsuranceSystem.Controllers
{
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class InsuranceController : ControllerBase
    {
        private readonly InsuranceDbContext _dbContext;
        private readonly ILogger<InsuranceController> _logger;

        public InsuranceController(InsuranceDbContext dbContext, ILogger<InsuranceController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpPost("claims")]
        public IActionResult SubmitClaim([FromBody] Policyholder policyholder)
        {
            try
            {
                // Input validation
                if (policyholder == null || !ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Validate policyholder data
                if (string.IsNullOrWhiteSpace(policyholder.NationalId) ||
                    string.IsNullOrWhiteSpace(policyholder.Name) ||
                    string.IsNullOrWhiteSpace(policyholder.Surname) ||
                    policyholder.DateOfBirth == default ||
                    string.IsNullOrWhiteSpace(policyholder.PolicyNumber))
                {
                    return BadRequest("Invalid policyholder data.");
                }

                // Ensure Claims collection is initialized
                policyholder.Claims ??= new List<Claim>();

                // Generate claimId (you can use a more sophisticated logic based on your needs)
                var claimId = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();

                // Calculate totalClaimAmount (you can adjust the calculation based on your needs)
                var totalClaimAmount = policyholder.Claims.Sum(c => c?.Expenses?.Sum(e => e.Amount) ?? 0);

                // Set status to "Submitted"
                var status = "Submitted";

                // Create a new claim
                var newClaim = new Claim
                {
                    ClaimId = claimId,
                    NationalId = policyholder.NationalId,
                    Expenses = policyholder.Claims?
                        .Where(c => c?.Expenses != null)
                        .SelectMany(c => c.Expenses ?? Enumerable.Empty<Expense>())
                        .ToList(),
                    TotalClaimAmount = totalClaimAmount,
                    Status = status
                };

                // Add the new claim to the policyholder
                policyholder.Claims?.Add(newClaim);

                // Add the policyholder to the database
                _dbContext.Policyholders.Add(policyholder);
                _dbContext.SaveChanges();

                return Ok(new { claimId, status = "Submitted" });
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while processing the claim.");

                return StatusCode(500, "An error occurred while processing the claim.");
            }
        }
    }
}
