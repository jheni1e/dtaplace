using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;
namespace dtaplace.UseCases.GetPixels;

public record GetPixelsPayload (
    int RoomID
);