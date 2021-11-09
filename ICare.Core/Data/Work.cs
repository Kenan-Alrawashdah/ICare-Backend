using System;

namespace ICare.Core.Data
{
    //TODO: 1234
    public class Work : BaseDataModel
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int EmployeeId { get; set; }

        //Niv
        public Employee Employee { get; set; }
    }
}