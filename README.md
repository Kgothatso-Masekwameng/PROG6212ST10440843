# PROG6212ST10440843
Claims Management System

Overview

A comprehensive web application for managing lecturer claims, built with ASP.NET Core MVC. This system allows lecturers to submit claims, coordinators to verify them, and managers to provide final approval in a streamlined workflow.

Features

🎯 Core Functionality

· Lecturer Portal: Submit claims with supporting documents and track status
· Coordinator Portal: Review and verify/reject pending claims
· Manager Portal: Final approval/rejection of coordinator-approved claims
· Real-time Status Tracking: Transparent progress through approval workflow
· Secure File Upload: Encrypted document storage with validation

📁 Document Management

· Secure file upload with AES encryption
· Supported formats: PDF, DOCX, XLSX
· File size limit: 5MB per file
· Encrypted storage and secure download

🛡️ Security Features

· File encryption at rest using AES
· Input validation using Data Annotations
· Anti-forgery tokens
· Secure file handling

Technology Stack

· Framework: ASP.NET Core MVC
· Storage: JSON file-based with in-memory caching
· Encryption: AES for file security
· Frontend: Bootstrap 5, Font Awesome
· Testing: xUnit for unit testing

Project Structure

```
ClaimsManagementApp/
├── Controllers/
│   ├── LecturerController.cs
│   ├── CoordinatorController.cs
│   └── ManagerController.cs
├── Models/
│   ├── Claim.cs
│   └── SupportingDocument.cs
├── Services/
│   ├── IClaimService.cs
│   ├── ClaimService.cs
│   ├── IFileService.cs
│   └── FileService.cs
├── Views/
│   ├── Lecturer/
│   ├── Coordinator/
│   └── Manager/
├── UnitTests/
└── Program.cs
```

Installation & Setup

Prerequisites

· .NET 6.0 SDK or later
· Visual Studio 2022 or VS Code

Installation Steps

1. Clone the repository
   ```bash
   git clone <repository-url>
   cd ClaimsManagementApp
   ```
2. Restore dependencies
   ```bash
   dotnet restore
   ```
3. Run the application
   ```bash
   dotnet run
   ```
4. Access the application
   · Open browser and navigate to: https://localhost:7000

User Guides

For Lecturers

1. Access Lecturer Portal: Click "Enter as Lecturer" on home page
2. Submit New Claim: Click "Submit New Claim" button
3. Fill Claim Form:
   · Enter lecturer name, hours worked, hourly rate
   · Add additional notes (optional)
   · Upload supporting documents (PDF, DOCX, XLSX)
4. Track Claim: View status and progress in claims list

For Coordinators

1. Access Coordinator Portal: Click "Enter as Coordinator" on home page
2. Review Pending Claims: View all claims awaiting verification
3. Verify/Reject Claims:
   · Download and review supporting documents
   · Click "Verify" to approve or "Reject" to deny
4. Status Updates: Claims automatically move to manager queue when verified

For Managers

1. Access Manager Portal: Click "Enter as Manager" on home page
2. Review Coordinator-Approved Claims: View claims verified by coordinators
3. Final Approval/Rejection:
   · Review claim details and documents
   · Click "Approve" for final approval or "Reject" to deny
4. Complete Workflow: Claims are settled after manager action

Claim Status Workflow

1. Pending → Claim submitted by lecturer
2. ApprovedByCoordinator → Verified by coordinator
3. RejectedByCoordinator → Rejected by coordinator
4. ApprovedByManager → Final approval by manager
5. RejectedByManager → Final rejection by manager
6. Settled → Claim processing complete

File Upload Specifications

· Allowed Formats: .pdf, .docx, .xlsx
· Maximum Size: 5MB per file
· Security: Files encrypted using AES before storage
· Validation: Client-side and server-side file validation

Unit Testing

The application includes comprehensive unit tests covering:

· Claim creation and retrieval
· Status updates
· Document management
· File validation

Run tests with:

```bash
dotnet test
```

API Endpoints

Lecturer Endpoints

· GET /Lecturer - View all claims
· GET /Lecturer/SubmitClaim - Claim submission form
· POST /Lecturer/SubmitClaim - Submit new claim
· GET /Lecturer/TrackClaim/{id} - Track specific claim

Coordinator Endpoints

· GET /Coordinator/PendingClaims - View pending claims
· POST /Coordinator/VerifyClaim - Verify a claim
· POST /Coordinator/RejectClaim - Reject a claim
· GET /Coordinator/DownloadDocument/{id} - Download document

Manager Endpoints

· GET /Manager/PendingClaims - View claims for final approval
· POST /Manager/ApproveClaim - Final approval
· POST /Manager/RejectClaim - Final rejection
· GET /Manager/DownloadDocument/{id} - Download document

Error Handling

· Comprehensive validation using Data Annotations
· Meaningful error messages for users
· Graceful handling of file upload errors
· Secure exception management

Security Implementation

· File Encryption: AES encryption for all uploaded documents
· Input Validation: Server-side and client-side validation
· Anti-Forgery: CSRF protection on all forms
· Secure Storage: Encrypted file storage with access control

Version Control

· Regular commits with descriptive messages
· Feature-based branching strategy
· Minimum 10+ commits as required by project specifications

Browser Compatibility

· Chrome 90+
· Firefox 88+
· Safari 14+
· Edge 90+

Support

For technical support or questions about the Claims Management System, please contact the development team or refer to the system documentation.

---

Built for PROG6212 - Advanced Programming Assignment
Demonstrating MVC architecture, file handling, encryption, and real-time status tracking
