using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OperationClaimDto:IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorizationRate { get; set; }
    }
}
