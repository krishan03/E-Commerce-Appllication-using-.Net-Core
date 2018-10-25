using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amcart.Business.AppService;
using Amcart.Business.AppService.DTOs;
using Amcart.Core.ValueObjects;
using Amcart.Core.WebMVC;
using Amcart.Core.WebMVC.Filters;
using Amcart.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Amcart.Web.Controllers
{
    public class ProductController : BaseController
    {
        private IProductAppService productAppService;
        private IMapper mapper;

        public ProductController(IProductAppService productAppService, IMapper mapper)
        {
            this.productAppService = productAppService;
            this.mapper = mapper;
        }

        [ActionFilter]
        [ExceptionFilterWeb("ExceptionDetails")]
        public IActionResult Index()
        {

            OperationResult<IEnumerable<ProductDTO>> productDTOList = productAppService.GetAllProducts();
            List<ProductViewModel> productViewModel = new List<ProductViewModel>();
            // throw new DivideByZeroException();
            productViewModel = mapper.Map<List<ProductDTO>, List<ProductViewModel>>(productDTOList.Data.ToList());

            return View("Index", productViewModel);
        }

        [ActionFilter]
        [ExceptionFilterWeb("ExceptionDetails")]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionFilter]
        [ExceptionFilterWeb("ExceptionDetails")]
        public IActionResult Create(
            [Bind("ProductName,PolicyTypeID,ProductCode,IRDACode,Remarks,ProposalIssueDaysLimit")] ProductViewModel productViewModel)
        {
            OperationResult<ProductDTO> result = null;
            if (ModelState.IsValid)
            {
                ProductDTO productDTO = mapper.Map<ProductViewModel, ProductDTO>(productViewModel);

                result = productAppService.Create(productDTO);
                return this.HandleResult<ProductDTO>(result, productViewModel, "Index", "Create");
            }
            return View("Create", productViewModel);
        }


    }
}