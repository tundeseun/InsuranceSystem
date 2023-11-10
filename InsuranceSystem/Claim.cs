using System;
using System.Collections.Generic;
namespace InsuranceSystem.Models;
public class Claim
{
    public int Id { get; set; }
    public string? ClaimId { get; set; }
    public string? NationalId { get; set; }
    public int PolicyholderId { get; set; } // Foreign key
    public Policyholder Policyholder { get; set; } = new Policyholder(); // Navigation property

    public List<Expense>? Expenses { get; set; }
    public decimal TotalClaimAmount { get; set; }
    public string? Status { get; set; }
}
