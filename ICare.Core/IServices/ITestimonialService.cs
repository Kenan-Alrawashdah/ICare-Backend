using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface ITestimonialService
    {
        bool CreateTestimonial(Testimonial testimonial);
        IEnumerable<Testimonial> GetAllTestimonial();
    }
}
