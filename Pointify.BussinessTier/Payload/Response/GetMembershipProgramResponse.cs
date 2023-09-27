namespace Pointify.BussinessTier.Payload.Response;

public class GetMembershipProgramResponse
{
    public GetMembershipProgramResponse(Guid id, Guid brandId, string? nameOfProgram, DateTime? startDay,
        DateTime? endDay, string? termAndConditions, string? status)
    {
        Id = id;
        BrandId = brandId;
        NameOfProgram = nameOfProgram;
        StartDay = startDay;
        EndDay = endDay;
        TermAndConditions = termAndConditions;
        Status = status;

    }

    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string? NameOfProgram { get; set; }
    public DateTime? StartDay { get; set; }
    public DateTime? EndDay { get; set; }
    public string? TermAndConditions { get; set; }
    public string? Status { get; set; }

}