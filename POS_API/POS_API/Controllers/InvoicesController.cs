using Microsoft.AspNetCore.Mvc;
using POS_API.DomainModels;
using POS_API.Services;
using POS_API.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;
        public InvoicesController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        // GET: api/<InvoicesController>
        [HttpGet("GetInvoiceDetails/{InvoiceId}")]
        public async Task<IEnumerable<InvoiceViewModel>> GetInvoiceDetails([FromRoute] int InvoiceId) =>
          await  invoiceService.GetInvoiceView(InvoiceId);
       

     

        // POST api/<InvoicesController>
        [HttpPost]
        public async Task<ActionResult> PostInvoice([FromBody] Invoice invoice)
        {
            var res =await invoiceService.PostInvoice(invoice);
            return res ? Created(nameof(PostInvoice), invoice) : BadRequest();
        }
        [HttpPost("PostProductsToInvoice")]
        public async Task<ActionResult> PostProductsToInvoice([FromBody]ProductInvoice productInvoice)
        {
            var res=await invoiceService.PostProductsToInvoice(productInvoice);
            return res ? Created(nameof(PostProductsToInvoice), productInvoice) : BadRequest();
        }
        [HttpPost("ConfirmInvoice/{InvoiceId}")]
        public async Task<ActionResult> ConfirmInvoice([FromRoute]int InvoiceId)
        {
            var res = await invoiceService.ConfirmInvoice(InvoiceId);
            return res ? Ok() : BadRequest();

        }
    }
}
