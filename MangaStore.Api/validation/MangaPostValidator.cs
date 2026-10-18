using FluentValidation;
using MangaStore.Api.MangasDTO;

namespace MangaStore.Api.MangaPostValidator;

public class MangaPostValidator : AbstractValidator<MangasPostDTO>
{
    public MangaPostValidator()
    {
        RuleFor(x => x.Author).NotEmpty().NotNull().Length(5,30).WithMessage("Довжина повинна бути від 5 до 30");
        RuleFor(x => x.Name).NotEmpty().NotNull().Length(5,30).WithMessage("Довжина повинна бути від 5 до 30");
        RuleFor(x => x.Price).NotNull().GreaterThan(0).WithMessage("Ціна повинна бути більше 0");;
    }
}