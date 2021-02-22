using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class TblApprovalStatus
    {
        public TblApprovalStatus()
        {
            TblApprove = new HashSet<TblApprove>();
        }

        public int ApprovalStatusId { get; set; }
        public string ApprovalStatus { get; set; }

        public ICollection<TblApprove> TblApprove { get; set; }
    }
}
