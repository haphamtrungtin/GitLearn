﻿namespace GitLearn.Services.Service
{
    public class TeamDTO
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
        public int? ParentTeamId { get; set; } // ParentTeamId
        public bool? IsParentTeam { get; set; } // IsParentTeam
        public bool? IsPublic { get; set; } // IsPublic
        public int? OrganizationId { get; set; } // OrganizationId
    }
}