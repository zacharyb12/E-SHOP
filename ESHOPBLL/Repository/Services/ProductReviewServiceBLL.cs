﻿using ESHOPBLL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._04.ProductReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPBLL.Repository.Services
{
    public class ProductReviewServiceBLL : IProductReviewServiceBLL
    {
        private readonly IProductReviewServiceDAL productReviewService;

        public ProductReviewServiceBLL(IProductReviewServiceDAL productReviewService)
        {
            this.productReviewService = productReviewService;
        }

        public void CreateProductReview(CreateProductReview product)
        {
            ProductReview productReview = new ProductReview()
            {
                ReviewDate = new DateTime(),
                ProductId = product.ProductId,
                UserId = product.UserId,
                Rating = product.Rating,
                ReviewText = product.ReviewText,
            };
            productReviewService.CreateProductReview(productReview);
        }


        public IEnumerable<ProductReview> GetProductReviews()
        {
            return productReviewService.GetProductReviews();
        }


        public ProductReview GetProductReviewById(Guid id)
        {
            return productReviewService.GetProductReviewById(id);
        }


        public IEnumerable<ProductReview> GetProductReviewByUserID(Guid id)
        {
            return productReviewService.GetProductReviewByUserId(id);
        }


        public IEnumerable<ProductReview> GetProductReviewByRating(int rating)
        {
            return productReviewService.GetProductReviewByRating(rating);
        }


        public IEnumerable<ProductReview> GetProductReviewByProductId(Guid id)
        {
            return productReviewService.GetProductReviewByProductId(id);
        }

    }
}
