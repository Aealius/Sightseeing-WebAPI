using Abp.Domain.Entities;
using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class ReviewService
    {
        private readonly IBaseRepository<Review> _repository;
        private readonly IMapper _mapper;

        public ReviewService(IBaseRepository<Review> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReviewDTOModel> Add(ReviewDTOModel addReviewDTO)
        {
            var review = _mapper.Map<Review>(addReviewDTO);
            await _repository.AddAsync(review);

            return _mapper.Map<ReviewDTOModel>(review);
        }

        public async Task<ReviewDTOModel> Delete(int id)
        {
            var review = _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(id);

            return _mapper.Map<ReviewDTOModel>(review);
        }

        public async Task<List<ReviewDTOModel>> GetAll()
        {
            var reviews = await _repository.GetAllAsync();
            var reviewsDTOList = new List<ReviewDTOModel>();
            foreach (var review in reviews)
            {
                reviewsDTOList.Add(_mapper.Map<Review, ReviewDTOModel>(review));
            }

            return reviewsDTOList;
        }

        public async Task<ReviewDTOModel> GetById(int id)
        {
            var review = _repository.GetByIdAsync(id);
            if (review == null)
            {
                throw new EntityNotFoundException("Review not found");
            }

            return _mapper.Map<ReviewDTOModel>(review);
        }

        public async Task<ReviewDTOModel?> Update(int id, ReviewDTOModel updateReviewDTO)
        {
            var review = _mapper.Map<Review>(updateReviewDTO);
            await _repository.UpdateAsync(id, review);

            return _mapper.Map<ReviewDTOModel>(review);
        }
    }
}
