using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class ReviewService
    {
        private readonly BaseRepository<Review> repository;
        private readonly IMapper mapper;
        public ReviewService(BaseRepository<Review> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ReviewDTOModel> Add(ReviewDTOModel addReviewDTO)
        {
            var review = mapper.Map<Review>(addReviewDTO);
            await repository.AddAsync(review);
            return mapper.Map<ReviewDTOModel>(review);
        }
        public async Task<ReviewDTOModel> Delete(int id)
        {
            var review = repository.GetByIdAsync(id);
            await repository.DeleteAsync(id);
            return mapper.Map<ReviewDTOModel>(review);
        }
        public async Task<List<ReviewDTOModel>> GetAll()
        {
            var reviews = await repository.GetAllAsync();
            var reviewsDTOList = new List<ReviewDTOModel>();
            foreach (var review in reviews)
            {
                reviewsDTOList.Add(mapper.Map<Review, ReviewDTOModel>(review));
            }
            return reviewsDTOList;
        }
        public async Task<ReviewDTOModel> GetById(int id)
        {
            var review = repository.GetByIdAsync(id);
            if (review == null)
                throw new ValidationException("Review not found");
            return mapper.Map<ReviewDTOModel>(review);
        }
        public async Task<ReviewDTOModel?> Update(int id, ReviewDTOModel updateReviewDTO)
        {
            var review = mapper.Map<Review>(updateReviewDTO);
            await repository.UpdateAsync(id, review);
            return mapper.Map<ReviewDTOModel>(review);
        }
    }
}
