
# Insurance System API

This API serves as a backend for an Insurance System that manages claims and policyholders.

Description

The Insurance System API facilitates the submission and tracking of claims by policyholders and supports administrative actions by claim processors. It allows users to submit their claims, track their statuses, and enables administrators to review, approve, or decline these claims.

Features

    Policyholder Details
        National ID number (required)
        Name (required)
        Surname (required)
        Date of Birth (required)
        Policy Number (required, alphanumeric)

    Claims Information
        Claim ID (required)
        Policyholder's National ID (required)
        Expenses
            Procedures (with the name of the procedure)
            Prescriptions (with the name of the medication)
            Amount of the Expense
            Date of Expense (required)
        Total amount to be claimed (calculated, not stored)
        Claim Status (required, default: 'Submitted')


 Installation and Setup

Prerequisites

    .NET SDK
    Visual Studio or Visual Studio Code

Running the Application

    Clone the Repository
    git clone https://github.com/tundeseun/InsuranceSystem


    Open the Project in Visual Studio or Visual Studio Code

    Set Up Database Connection
        Open appsettings.json.
        Update the connection string with your SQL Server credentials.

    Run the Application
        Rebuild the project.
        Start the API.
        The API will run at http://localhost:5000.

API Endpoints

    GET /api/policyholders
        Retrieve details of all policyholders.

    POST /api/claims
        Submit a claim.
        Request body: Details of the claim.

    PUT /api/claims/{claimId}
        Update the status of a specific claim.
        Request body: New claim status.

Usage

    Submit a Claim
        Use the POST /api/claims endpoint with the required claim details.

    Review or Update Claims
        Access the GET endpoints to view data.
        Use the PUT endpoint to update the status of a specific claim.

Testing

Use Postman or a similar tool to simulate API requests. Test the POST and PUT endpoints to submit claims and update claim statuses.
