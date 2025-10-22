﻿using ClaimsManagementApp.Models;
using System.Text.Json;

namespace ClaimsManagementApp.Services
{
    public class ClaimService : IClaimService
    {
        private List<Claim> _claims;
        private readonly string _dataFile = "claims.json";
        private readonly IFileService _fileService;

        public ClaimService(IFileService fileService)
        {
            _fileService = fileService;
            LoadClaims();
        }

        private void LoadClaims()
        {
            if (File.Exists(_dataFile))
            {
                var json = File.ReadAllText(_dataFile);
                _claims = JsonSerializer.Deserialize<List<Claim>>(json) ?? new List<Claim>();
            }
            else
            {
                _claims = new List<Claim>();
            }
        }

        private void SaveClaims()
        {
            var json = JsonSerializer.Serialize(_claims, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_dataFile, json);
        }

        public List<Claim> GetAllClaims() => _claims;

        public Claim GetClaimById(int id) => _claims.FirstOrDefault(c => c.Id == id);

        public void AddClaim(Claim claim)
        {
            claim.Id = _claims.Count > 0 ? _claims.Max(c => c.Id) + 1 : 1;
            _claims.Add(claim);
            SaveClaims();
        }

        public void UpdateClaimStatus(int claimId, ClaimStatus status)
        {
            var claim = GetClaimById(claimId);
            if (claim != null)
            {
                claim.Status = status;
                SaveClaims();
            }
        }

        public List<Claim> GetClaimsByStatus(ClaimStatus status)
            => _claims.Where(c => c.Status == status).ToList();

        public void AddDocumentToClaim(int claimId, SupportingDocument document)
        {
            var claim = GetClaimById(claimId);
            if (claim != null)
            {
                document.Id = claim.Documents.Count > 0 ? claim.Documents.Max(d => d.Id) + 1 : 1;
                document.ClaimId = claimId;
                claim.Documents.Add(document);
                SaveClaims();
            }
        }

        public SupportingDocument GetDocument(int documentId)
        {
            return _claims.SelectMany(c => c.Documents)
                         .FirstOrDefault(d => d.Id == documentId);
        }
    }
}