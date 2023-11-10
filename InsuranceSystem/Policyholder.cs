using System;
using System.Collections.Generic;
namespace InsuranceSystem.Models;

public class Policyholder
{
    public int Id { get; set; }
    public string? NationalId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? PolicyNumber { get; set; }
    public List<Claim>? Claims { get; set; }
}
