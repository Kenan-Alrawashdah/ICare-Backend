using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {

        private readonly ITestimonialService _testimonialService;

        public TestimonialController( ITestimonialService testimonialService)
        {

            this._testimonialService = testimonialService;
        }
        
        [HttpPost]
        [Route("AddNewTestimonial")]
        public async Task<ActionResult<ApiResponse>> AddNewTestimonial(Testimonial testimonial)
        {
            var response = new ApiResponse();
            var result =  _testimonialService.CreateTestimonial(testimonial);
            if (result == false)
            {
                response.AddError("something wrong");
                return Ok(response);
            }


            return Ok(response);
            
        }
        [HttpGet]
        [Route("GetAllTestimonial")]
        public ActionResult<ApiResponse<Testimonial>> GetAllTestimonial()
        {

            var response = new ApiResponse<IEnumerable<Testimonial>>();
            var testimonialList = _testimonialService.GetAllTestimonial();
            if (testimonialList == null)
            {
                response.AddError("no Testimonial for display");
                return Ok(response);
            }
            response.Data = new List<Testimonial>();
            response.Data = testimonialList;
            return Ok(response);


        }
    }
}
