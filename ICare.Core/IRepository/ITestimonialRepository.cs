using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IRepository
{
    public interface ITestimonialRepository
    {
        bool CreateTestimonial(Testimonial testimonial);


        IEnumerable<Testimonial> GetAllTestimonial();
    }
}
