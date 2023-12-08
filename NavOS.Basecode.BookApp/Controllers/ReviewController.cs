using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NavOS.Basecode.BookApp.Mvc;
using NavOS.Basecode.Data.Models;
using NavOS.Basecode.Services.Interfaces;
using NavOS.Basecode.Services.ServiceModels;
using NavOS.Basecode.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NavOS.Basecode.BookApp.Controllers
{
    public class ReviewController : ControllerBase<ReviewController>
    {
        private readonly IReviewService _reviewService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="mapper"></param>
        public ReviewController(IReviewService reviewService,
                              IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IMapper mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _reviewService = reviewService;
        }
        /// <summary>
        /// Adds the review.
        /// </summary>
        /// <param name="review">The review.</param>
        /// <returns></returns>
        public async Task<IActionResult> AddReview(ReviewViewModel review)
        {
            var isEmailValid = await _reviewService.CheckEmailValidAsync(review.UserEmail);

            review.ReviewText = string.IsNullOrEmpty(review.ReviewText) ? string.Empty : review.ReviewText;

            if (_reviewService.ContainsBadWords(review.ReviewText) || _reviewService.ContainsBadWords(review.UserName))
            {
                TempData["ErrorMessage"] = "Prohibited words detected.";
                return RedirectToAction("BookDetails", "Book", new { review.BookId });
            }

            if (!isEmailValid)
            {
                TempData["ErrorMessage"] = "Invalid Email";
                return RedirectToAction("BookDetails", "Book", new { review.BookId });
            }

            string host = HttpContext.Request.Host.ToString();
            _reviewService.AddReview(review, host);
            TempData["SuccessMessage"] = "Review Added Successfully.";
            return RedirectToAction("BookDetails", "Book", new { review.BookId });
        }

        /// <summary>
        /// Reviews the details.
        /// </summary>
        /// <returns></returns>
        public IActionResult ReviewDetails()
        {
            return View();
        }
    }
}
