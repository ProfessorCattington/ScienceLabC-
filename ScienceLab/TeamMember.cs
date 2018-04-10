using System.Collections.Generic;

namespace ScienceLab
{
    class TeamMember
    {
        public string name;
        public string managerName;
        public string role;
        public string year;

        public TeamMember reportsToMember;

        public TeamMember CEO;
        public List<TeamMember> subordinates;
    }
}
