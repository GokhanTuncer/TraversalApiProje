using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalApiProje.Controllers.DAL.Context;
using TraversalApiProje.Controllers.DAL.Entities;

namespace TraversalApiProje.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values==null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);
                }
               
            }
        }
        [HttpGet("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Remove(values);
                    context.SaveChanges();
                    return Ok();
                }

            }
        }
        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Find<Visitor>(visitor.VisitorID);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    values.City = visitor.City;
                    values.Country = visitor.Country;
                    values.Name = visitor.Name;
                    values.Surname = visitor.Surname;
                    values.Mail = visitor.Mail;
                    context.Update(values);
                    context.SaveChanges(
                        );
                    return Ok();
                }

            }
        }

    }
}
