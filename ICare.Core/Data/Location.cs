using System.ComponentModel.DataAnnotations;

namespace ICare.Core.Data
{
    public class Location : BaseDataModel
    {

        [MaxLength(50)]
        public string AddressName { get; set; }

        public int UserId { get; set; }


        [MaxLength(50)]
        public string PhoneNumber { get; set; }


        [MaxLength(50)]
        public string City { get; set; }

        public int? ZipCode { get; set; }
        public double? lat { get; set; }
        public double? lng { get; set; }

        [MaxLength(50)]
        public string Details { get; set; }

        [MaxLength(50)]
        public string Street { get; set; }
    }
}