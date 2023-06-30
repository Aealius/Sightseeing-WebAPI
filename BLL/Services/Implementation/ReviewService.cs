using Abp.Domain.Entities;
using AutoMapper;
using BLL.Models;
using BLL.Services.Contracts;
using DAL.Entities;
using IUnitOfWork = DAL.UnitOfWork.IUnitOfWork;

namespace BLL.Services.Implementation
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(ReviewDTOModel addReviewDTO)
        {
            var review = _mapper.Map<Review>(addReviewDTO);
            await _unitOfWork.Reviews.AddAsync(review);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(uint id)
        {
            await _unitOfWork.Reviews.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ReviewDTOModel>> GetAllAsync()
        {
            var reviews = await _unitOfWork.Reviews.GetAllAsync();
            var reviewsDTOList = new List<ReviewDTOModel>();
            foreach (var review in reviews)
            {
                reviewsDTOList.Add(_mapper.Map<ReviewDTOModel>(review));
            }

            return reviewsDTOList;
        }

        public async Task<ReviewDTOModel> GetByIdAsync(uint id)
        {
            var review = await _unitOfWork.Reviews.GetByIdAsync(id);

            if (review == null)
            {
                throw new EntityNotFoundException("Review not found");
            }

            var reviewDTO = _mapper.Map<ReviewDTOModel>(review);

            return reviewDTO;
        }

        public async Task UpdateAsync(uint id, ReviewDTOModel updateReviewDTO)
        {
            var review = _mapper.Map<Review>(updateReviewDTO);
            await _unitOfWork.Reviews.UpdateAsync(id, review);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
