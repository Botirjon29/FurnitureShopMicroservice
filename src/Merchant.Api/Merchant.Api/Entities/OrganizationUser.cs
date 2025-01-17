﻿using System.ComponentModel.DataAnnotations.Schema;
using Merchant.Api.Dtos;
using Merchant.Api.Dtos.Enums;

namespace Merchant.Api.Entities;

public class OrganizationUser
{
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual AppUser? User { get; set; }
    public Guid OrganizationId { get; set; }
    [ForeignKey(nameof(OrganizationId))]
    public virtual Organization Organization { get; set; }
    public ERole Role { get; set; }
}