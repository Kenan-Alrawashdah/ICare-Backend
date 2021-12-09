using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        public bool CreateTestimonial(Testimonial testimonial)
        {
            return _testimonialRepository.CreateTestimonial(testimonial);
        }
        public IEnumerable<Testimonial> GetAllTestimonial()
        {
            return _testimonialRepository.GetAllTestimonial();
        }
    }
}
